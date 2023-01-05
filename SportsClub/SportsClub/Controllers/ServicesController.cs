using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsClub.Data;
using SportsClub.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SportsClub.Controllers
{
    public class ServicesController : Controller
    {
        private readonly SportsClubContext _context;
        public ServicesController(SportsClubContext context)
        {
            _context = context;
        }
        public IActionResult Index() => View();
        [HttpGet]
        public async Task<IActionResult> Services(string categoryName = "", int p = 1, string serviceSearch = "")
        {
            ViewData["Search"] = serviceSearch;
            int pageSize = 4;
            ViewBag.PageNumber = p;
            ViewBag.PageRange = pageSize;
            ViewBag.CategorySlug = categoryName;
            IQueryable<Service> searchedServices;

            if (categoryName == "")
            {
                ViewBag.CategoryName = "Усі послуги";
                searchedServices = _context.Services.Where(s => s.Name.Contains(serviceSearch) || serviceSearch == null);
                ViewBag.TotalPages = (int)Math.Ceiling((decimal)searchedServices.Count() / pageSize);
                return View(await searchedServices.OrderByDescending(s => s.Id)
                    .Include(s => s.Category)
                    .Skip((p - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync());
            }

            var category = await _context.Categories.Where(c => c.URLFriendlyName == categoryName).FirstOrDefaultAsync();
            ViewBag.CategoryName = category.Name;
            if (category == null)
            {
                return RedirectToAction("Index");
            }

            var servicesByCategory = _context.Services.Where(s => s.CategoryId == category.Id);
            searchedServices = servicesByCategory.Where(s => s.Name.Contains(serviceSearch) || serviceSearch == null); 
            ViewBag.TotalPages = (int)Math.Ceiling((decimal)searchedServices.Count() / pageSize);

            return View(await searchedServices.OrderByDescending(p => p.Id)
                     .Include(s => s.Category)
                     .Skip((p - 1) * pageSize)
                     .Take(pageSize).ToListAsync());
        }

        public async Task<IActionResult> Details(long serviceId)
        {
            var service = _context.Services.FirstOrDefault(s => s.Id == serviceId);
            service.Category = _context.Categories.FirstOrDefault(c => c.Id == service.CategoryId);
            return View(service);
        }
    }
}
