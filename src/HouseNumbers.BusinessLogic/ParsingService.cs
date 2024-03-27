﻿using HouseNumbers.BusinessLogic.Models;
using Microsoft.Extensions.Options;

namespace HouseNumbers.BusinessLogic
{
    public interface IParsingService
    {
        List<HouseNumberDetails> ParseCsv(string path);
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

        public List<HouseNumberDetails> ParseCsv(string path)
        {
            if (!File.Exists(path))
                throw new ArgumentException($"No file exists at '{path}'");

            var data = File.ReadAllLines(path);
            var result = new List<HouseNumberDetails>();

            for (int i = 0; i < data.Length; i++)
            {
                var line = data[i];
                var columns = line.Split(';');

                if (int.TryParse(columns[0], out int number) && number > 0)
                {
                    string? suffix = null;

                    if (columns.Length > 1)
                    {
                        var suffixParsed = columns[1].Trim().ToUpper();

                        if (suffixParsed.Length == 1 && IsAllowedSuffix(suffixParsed[0]))
                        {
                            suffix = suffixParsed;
                        }
                    }

                    var details = new HouseNumberDetails
                    {
                        Number = number,
                        Suffix = suffix
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

        public bool IsAllowedSuffix(char character)
        {
            for(int i = 0; i < AllowedCharacters.Length; i++)
            {
                if (AllowedCharacters[i] == character)
                    return true;
            }

            return false;
        }
    }
}
