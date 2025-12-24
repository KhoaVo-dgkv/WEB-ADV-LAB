using System.Diagnostics;
using Lab08.Data;
using Lab08.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab08.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new DashboardViewModel
            {
                TotalBrands = await _context.Brands.CountAsync(),
                TotalCarModels = await _context.CarModels.CountAsync(),
                TotalCars = await _context.Cars.CountAsync(),
                AvailableCars = await _context.Cars.CountAsync(c => c.IsAvailable)
            };

            // Get car counts by brand for chart
            var brandCarCounts = await _context.Cars
                .Include(c => c.CarModel)
                .ThenInclude(cm => cm.Brand)
                .GroupBy(c => c.CarModel.Brand.Name)
                .Select(g => new BrandCarCount
                {
                    BrandName = g.Key,
                    CarCount = g.Count()
                })
                .OrderByDescending(b => b.CarCount)
                .Take(6)
                .ToListAsync();

            viewModel.BrandCarCounts = brandCarCounts;

            // Get recent cars for table (limit to 5)
            viewModel.RecentCars = await _context.Cars
                .Include(c => c.CarModel)
                .ThenInclude(cm => cm.Brand)
                .OrderByDescending(c => c.Id)
                .Take(5)
                .ToListAsync();

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
