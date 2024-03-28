namespace HouseNumbers.BusinessLogic.Sorting
{
    public enum SortingServiceType
    {
        // Include Unknown as first entry so we don't have to use nullable enums and we know when a value wasn't explicity set
        Unknown,

        BubbleSortService,

        QuickSortService
    }
}
