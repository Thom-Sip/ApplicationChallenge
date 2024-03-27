namespace HouseNumbers.BusinessLogic
{
    public interface ISortingService
    {
        void Sort<T>(List<T> list) where T : IComparable<T>;
    }

    public class BubbleSortService : ISortingService
    {
        public void Sort<T>(List<T> list) where T : IComparable<T>
        {
            var steps = 0;

            for (int i = 0; i < list.Count - 1; i++)
            {
                bool swapped = false;

                for (int j = 0; j < list.Count - i - 1; j++)
                {
                    steps++;
                    var first = list[j];
                    var second = list[j + 1];
                    var compare = first.CompareTo(second);
                    if (compare == 1)
                    {
                        var temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                        swapped = true;
                    }
                }

                if (!swapped)
                {
                    break;
                }
            }
        }
    }
}
