namespace HouseNumbers.BusinessLogic.Sorting
{
    public class QuickSortService : ISortingService
    {
        public void Sort<T>(List<T> list, SortOrder order) where T : IComparable<T>
        {
            QuickSort(list, 0, list.Count - 1, order);
        }

        private void QuickSort<T>(List<T> list, int start, int end, SortOrder order) where T : IComparable<T>
        {
            // We keep adjusting the start and end position, once start >= end we know that we finished sorting this partition
            if(start < end)
            {
                // First we place all elements > our pivot to the right, and all elements smaller to the left.
                int pivotIndex = ProcessPartition(list, start, end, order);

                // next we do this recursively for both sides of our newly returned pivot index
                QuickSort(list, start, pivotIndex - 1, order);
                QuickSort(list, pivotIndex + 1, end, order);
            }
        }

        private int ProcessPartition<T>(List<T> list, int start, int end, SortOrder order) where T : IComparable<T>
        {
            // Take the last element of the current sequence as the pivot
            T pivot = list[end];

            // Our firstSwapIndex is set to start -1 since no swap has happened yet during this iteration
            int firstSwapIndex = start - 1;

            // loop over all elements in the current partition
            for (int currentIndex = start; currentIndex < end; currentIndex++)
            {
                // Get the Value from the current Index
                var current = list[currentIndex];

                // if the current element is smaller or greater (depending on requested sortOrder) than the pivot element
                if (current.CompareTo(pivot) == GetCompareResultRequiredForSwap(order))
                {
                    // Increment our first Swap index.
                    // We know now that the Pivot should be placed after the current at the end of this iteration
                    firstSwapIndex++;

                    // and swap Current item with our first Swap index
                    Swap(list, firstSwapIndex, currentIndex);
                }
            }

            // Now swap our Pivot (end) with the first element after the last element we swapped
            Swap(list, firstSwapIndex + 1, end);

            // return our new pivot index
            return firstSwapIndex + 1;
        }

        private int GetCompareResultRequiredForSwap(SortOrder order)
        {
            return order switch
            {
                SortOrder.Ascending => -1,
                SortOrder.Descending => 1,
                _ => throw new ArgumentException($"{nameof(SortOrder)}: {order} is not valid")
            };
        }

        private static void Swap<T>(List<T> list, int x, int y)
        {
            (list[x], list[y]) = (list[y], list[x]);
        }
    }
}
