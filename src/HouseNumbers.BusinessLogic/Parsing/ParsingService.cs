using HouseNumbers.BusinessLogic.Models;
using Microsoft.Extensions.Options;
using System.Text.RegularExpressions;

namespace HouseNumbers.BusinessLogic.Parsing
{
    public interface IParsingService
    {
        List<HouseNumberDetails> ParseCsv();
    }

    public class ParsingService : IParsingService
    {
        ParseSettings Settings { get; init; }
        public string AllowedCharacters { get; init; }

        public ParsingService(IOptions<ParseSettings> parseSettings)
        {
            Settings = parseSettings.Value;
            AllowedCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        }

        public List<HouseNumberDetails> ParseCsv()
        {
            if (!File.Exists(Settings.FileName))
                throw new ArgumentException($"No file exists at '{Settings.FileName}'");

            var data = File.ReadAllLines(Settings.FileName);
            var result = new List<HouseNumberDetails>();

            for (int i = 1; i < data.Length; i++)
            {
                var line = data[i];
                var columns = SplitRowIntoColumns(line, Settings.ColumnDelimiterType);

                if (int.TryParse(columns[0], out int number) && number > 0)
                {
                    string? suffix = null;

                    if (columns.Length > 1 && columns[1].Length > 0)
                    {
                        var suffixParsed = columns[1].Trim().ToUpper();

                        if (IsValidSuffix(suffixParsed))
                        {
                            suffix = suffixParsed;
                        }
                    }

                    var details = new HouseNumberDetails
                    {
                        Number = number,
                        Suffix = suffix,
                    };

                    bool AlreadyExists = false;
                    if (!Settings.AllowDuplicates)
                    {
                        for (int k = 0; k < result.Count; k++)
                        {
                            if (result[k].CompareTo(details) == 0)
                            {
                                AlreadyExists = true;
                                break;
                            }
                        }
                    }

                    if (!AlreadyExists)
                    {
                        result.Add(details);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Most of the csv using semicolons as coloumn delimiter, but part of it using tabs.
        /// Implementation support either or both methods per row.
        /// </summary>
        static string[] SplitRowIntoColumns(string row, ColumnDelimiterType columnDelimiterType)
        {
            if (columnDelimiterType == ColumnDelimiterType.Both)
            {
                var cols = row.Split(';');

                return cols.Length > 1
                    ? cols
                    : row.Split('\t');
            }

            return columnDelimiterType switch
            {
                ColumnDelimiterType.Semicolon => row.Split(';'),
                ColumnDelimiterType.Tabs => row.Split('\t'),
                _ => throw new ArgumentException($"Config Settings {nameof(ColumnDelimiterType)} {columnDelimiterType} is not supported")
            };
        }

        bool IsValidSuffix(string suffix)
        {
            return Settings.SuffixValidationType switch
            {
                SuffixValidationType.Static => IsValiStaticSuffix(suffix, Settings.StaticSuffixValidation),
                SuffixValidationType.Regex => IsValidRegexSuffix(suffix, Settings.RegexSuffixValidation),
                _ => throw new ArgumentException(
                    $"Config Settings {nameof(SuffixValidationType)} {Settings.SuffixValidationType} is not supported")
            };
        }

        bool IsValiStaticSuffix(string suffix, StaticSuffixValidation? settings)
        {
            if (settings == null)
                throw new ArgumentException(
                    $"You are using {nameof(StaticSuffixValidation)} but the property is missing from the appsettings");

            if (suffix.Length > settings.MaxCharacters)
                return false;

            for(int i = 0; i < suffix.Length; i++)
            {
                if (!IsvalidStaticCharacter(suffix[i], settings.AllowedCharacters))
                    return false;
            }

            return true;
        }

        static bool IsvalidStaticCharacter(char character, string allowedCharacters)
        {
            for(int i = 0; i < allowedCharacters.Length; i++)
            {
                if (character == allowedCharacters[i])
                    return true;
            }

            return false;
        }

        static bool IsValidRegexSuffix(string suffix, RegexSuffixValidation? settings)
        {
            if(settings == null)
                throw new ArgumentException(
                    $"You are using {nameof(RegexSuffixValidation)} but the property is missing from the appsettings");

            return Regex.IsMatch(suffix, settings.Regex);
        }
    }
}
