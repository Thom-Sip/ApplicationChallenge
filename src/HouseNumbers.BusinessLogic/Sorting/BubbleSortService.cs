namespace HouseNumbers.BusinessLogic.Sorting
{
    public class BubbleSortService : ISortingService
    {
        public int Swaps = 0;

        public void Sort<T>(List<T> list) where T : IComparable<T>
        {
            // Iterate over all items in the array except the last one
            for (int i = 0; i < list.Count - 1; i++)
            {
                // If not a single swap needed to happen during the inner loop, it means we finished sorting early.
                // Keep track of this so we can break.
                bool swapped = false;

                // Iterate over all items from start till the end that has already been sorted
                for (int j = 0; j < list.Count - i - 1; j++)
                {
                    // Check if the current element is greater than the next element using a custom CompareTo() Implementation
                    var compare = list[j].CompareTo(list[j + 1]);
                    if (compare == 1)
                    {
                        // Swap the values when current is greater than next
                        (list[j], list[j + 1]) = (list[j + 1], list[j]);
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
