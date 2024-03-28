namespace HouseNumbers.BusinessLogic.Parsing
{
    public class ParseSettings
    {
        public required string FileName { get; init; }

        public required bool AllowDuplicates { get; init; }

        public required ColumnDelimiterType ColumnDelimiterType { get; init; }

        public required SuffixValidationType SuffixValidationType { get; init; }

        public StaticSuffixValidation? StaticSuffixValidation { get; init; }

        public RegexSuffixValidation? RegexSuffixValidation { get; init; }
    }

    public class StaticSuffixValidation
    {
        public required string AllowedCharacters { get; init; }

        public required int MaxCharacters { get; init; }
    }

    public class RegexSuffixValidation
    {
        public required string Regex { get; init; }
    }
}
