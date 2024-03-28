namespace HouseNumbers.BusinessLogic.Sorting
{
    public class SortingServiceFactory
    {
        Dictionary<SortingServiceType, ISortingService> Services { get; set; } = [];

        public SortingServiceFactory()
        {
            Register(SortingServiceType.BubbleSortService, new BubbleSortService());
            Register(SortingServiceType.QuickSortService, new QuickSortService());
        }

        private void Register(SortingServiceType type, ISortingService service)
        {
            if (Services.ContainsKey(type))
                throw new ArgumentException($"a {nameof(ISortingService)} has already been registered using {type}");

            Services.Add(type, service);
        }

        public ISortingService GetService(SortingServiceType type)
        {
            if (!Services.ContainsKey(type))
                throw new ArgumentException($"No {nameof(ISortingService)} has been registered using {type}");

            return Services[type];
        }
    }
}
