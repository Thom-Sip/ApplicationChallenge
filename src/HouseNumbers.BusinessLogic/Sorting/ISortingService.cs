namespace HouseNumbers.BusinessLogic.Sorting
{
    public interface ISortingService
    {
        void Sort<T>(List<T> list) where T : IComparable<T>;
    }
}
