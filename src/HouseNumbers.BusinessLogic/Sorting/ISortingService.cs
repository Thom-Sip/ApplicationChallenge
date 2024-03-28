namespace HouseNumbers.BusinessLogic.Sorting
{
    public interface ISortingService
    {
        void Sort<T>(List<T> list, SortOrder order) where T : IComparable<T>;
    }
}
