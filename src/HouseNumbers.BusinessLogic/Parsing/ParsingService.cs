using HouseNumbers.BusinessLogic.Models;
using System.Text.RegularExpressions;

namespace HouseNumbers.BusinessLogic.Parsing
{
    public interface IParsingService
    {
        List<HouseNumberDetails> ParseCsv(ParseSettings settings);
    }

    public class ParsingService : IParsingService
    {
        public List<HouseNumberDetails> ParseCsv(ParseSettings settings)
        {
            if (!File.Exists(settings.FileName))
                throw new ArgumentException($"No file exists at '{settings.FileName}'");

            var data = File.ReadAllLines(settings.FileName);
            var result = new List<HouseNumberDetails>();

            // Skip the first line since this is the header of the csv
            for (int i = 1; i < data.Length; i++)
            {
                var line = data[i];
                var cells = SplitLineIntoCells(line, settings.ColumnDelimiterType);

                if (int.TryParse(cells[0], out int number) && number > 0)
                {
                    var details = new HouseNumberDetails
                    {
                        Number = number,
                        Suffix = GetSuffix(cells, settings.SuffixValidationRegex),
                    };

                    if(settings.AllowDuplicates || !Contains(result, details))
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
        static string[] SplitLineIntoCells(string row, ColumnDelimiterType columnDelimiterType)
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

        /// <summary>
        /// Extract the Suffix from the row data
        /// </summary>
        static string GetSuffix(string[] columns, string regex)
        {
            if (columns.Length > 1 && columns[1].Length > 0)
            {
                var suffix = columns[1].Trim().ToUpper();

                if (Regex.IsMatch(suffix, regex))
                {
                    return suffix;
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Check if an new record already exists in the result
        /// </summary>
        static bool Contains(List<HouseNumberDetails> result, HouseNumberDetails newEntry)
        {
            for (int i = 0; i < result.Count; i++)
            {
                if (result[i].CompareTo(newEntry) == 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
