using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Lab08.Models;

namespace Lab08.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships
            modelBuilder.Entity<CarModel>()
                .HasOne(cm => cm.Brand)
                .WithMany(b => b.CarModels)
                .HasForeignKey(cm => cm.BrandId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Car>()
                .HasOne(c => c.CarModel)
                .WithMany(cm => cm.Cars)
                .HasForeignKey(c => c.CarModelId)
                .OnDelete(DeleteBehavior.Cascade);

            // Seed data
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // Seed Brands
            modelBuilder.Entity<Brand>().HasData(
                new Brand { Id = 1, Name = "Toyota", Description = "Japanese automotive manufacturer", Country = "Japan", EstablishedYear = new DateTime(1937, 8, 28) },
                new Brand { Id = 2, Name = "Honda", Description = "Japanese automotive manufacturer", Country = "Japan", EstablishedYear = new DateTime(1948, 9, 24) },
                new Brand { Id = 3, Name = "Ford", Description = "American automotive manufacturer", Country = "USA", EstablishedYear = new DateTime(1903, 6, 16) },
                new Brand { Id = 4, Name = "BMW", Description = "German luxury automotive manufacturer", Country = "Germany", EstablishedYear = new DateTime(1916, 3, 7) },
                new Brand { Id = 5, Name = "Mercedes-Benz", Description = "German luxury automotive manufacturer", Country = "Germany", EstablishedYear = new DateTime(1926, 6, 28) }
            );

            // Seed Car Models
            modelBuilder.Entity<CarModel>().HasData(
                new CarModel { Id = 1, Name = "Camry", Description = "Mid-size sedan", Year = 2023, Price = 25000, Engine = "2.5L 4-cylinder", FuelType = "Gasoline", Transmission = "Automatic", BrandId = 1 },
                new CarModel { Id = 2, Name = "Corolla", Description = "Compact sedan", Year = 2023, Price = 22000, Engine = "1.8L 4-cylinder", FuelType = "Gasoline", Transmission = "CVT", BrandId = 1 },
                new CarModel { Id = 3, Name = "Civic", Description = "Compact car", Year = 2023, Price = 23000, Engine = "2.0L 4-cylinder", FuelType = "Gasoline", Transmission = "CVT", BrandId = 2 },
                new CarModel { Id = 4, Name = "Accord", Description = "Mid-size sedan", Year = 2023, Price = 26000, Engine = "1.5L Turbo", FuelType = "Gasoline", Transmission = "CVT", BrandId = 2 },
                new CarModel { Id = 5, Name = "F-150", Description = "Full-size pickup truck", Year = 2023, Price = 35000, Engine = "3.3L V6", FuelType = "Gasoline", Transmission = "Automatic", BrandId = 3 },
                new CarModel { Id = 6, Name = "3 Series", Description = "Luxury compact sedan", Year = 2023, Price = 42000, Engine = "2.0L Turbo", FuelType = "Gasoline", Transmission = "Automatic", BrandId = 4 },
                new CarModel { Id = 7, Name = "C-Class", Description = "Luxury compact sedan", Year = 2023, Price = 45000, Engine = "2.0L Turbo", FuelType = "Gasoline", Transmission = "Automatic", BrandId = 5 }
            );

            // Seed Cars
            modelBuilder.Entity<Car>().HasData(
                new Car { Id = 1, LicensePlate = "ABC-123", VIN = "1HGBH41JXMN109186", Color = "White", Mileage = 15000, CurrentPrice = 23000, Condition = "Excellent", PurchaseDate = new DateTime(2022, 1, 15), Notes = "Well maintained", IsAvailable = true, CarModelId = 1 },
                new Car { Id = 2, LicensePlate = "XYZ-789", VIN = "2HGBH41JXMN109187", Color = "Black", Mileage = 25000, CurrentPrice = 20000, Condition = "Good", PurchaseDate = new DateTime(2021, 6, 10), Notes = "Minor scratches", IsAvailable = true, CarModelId = 2 },
                new Car { Id = 3, LicensePlate = "DEF-456", VIN = "3HGBH41JXMN109188", Color = "Red", Mileage = 8000, CurrentPrice = 21000, Condition = "Excellent", PurchaseDate = new DateTime(2022, 8, 20), Notes = "Like new", IsAvailable = true, CarModelId = 3 },
                new Car { Id = 4, LicensePlate = "GHI-321", VIN = "4HGBH41JXMN109189", Color = "Blue", Mileage = 30000, CurrentPrice = 24000, Condition = "Good", PurchaseDate = new DateTime(2021, 3, 5), Notes = "Regular maintenance", IsAvailable = false, CarModelId = 4 },
                new Car { Id = 5, LicensePlate = "JKL-654", VIN = "5HGBH41JXMN109190", Color = "Silver", Mileage = 12000, CurrentPrice = 32000, Condition = "Excellent", PurchaseDate = new DateTime(2022, 5, 12), Notes = "Low mileage", IsAvailable = true, CarModelId = 5 }
            );
        }
    }
}
