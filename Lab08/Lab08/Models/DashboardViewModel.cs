namespace Lab08.Models
{
    public class DashboardViewModel
    {
        public int TotalBrands { get; set; }
        public int TotalCarModels { get; set; }
        public int TotalCars { get; set; }
        public int AvailableCars { get; set; }
        public List<BrandCarCount> BrandCarCounts { get; set; } = new List<BrandCarCount>();
        public List<Car> RecentCars { get; set; } = new List<Car>();
    }

    public class BrandCarCount
    {
        public string BrandName { get; set; } = string.Empty;
        public int CarCount { get; set; }
    }
}

