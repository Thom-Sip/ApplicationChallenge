namespace HouseNumbers.BusinessLogic.Parsing
{
    public class ParseSettings
    {
        public required string FileName { get; init; }

        public required bool AllowDuplicates { get; init; }

        public required ColumnDelimiterType ColumnDelimiterType { get; init; }

        public required string SuffixValidationRegex { get; init; }
    }
}
