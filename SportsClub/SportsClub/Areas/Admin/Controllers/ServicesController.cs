using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportsClub.Data;
using SportsClub.Models;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SportsClub.Areas.Admin.Controllers
{
    
    [Authorize(Roles = "Адміністратор")]
    [Area("Admin")]
    public class ServicesController : Controller
    {
        private readonly SportsClubContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ServicesController(SportsClubContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Index(int p = 1)
        {
            int pageSize = 3;
/*            ViewBag.PageNumber = p;
            ViewBag.PageRange = pageSize;
            ViewBag.TotalPages = (int)Math.Ceiling((decimal)_context.Services.Count() / pageSize);*/
            return View(await _context.Services.OrderByDescending(s => s.Id)
                   .Include(s => s.Category)
/*                   .Skip((p - 1) * pageSize)
                   .Take(pageSize)*/
                   .ToListAsync());
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name");

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Service service)
        {
            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name", service.CategoryId);
            if (ModelState.IsValid)
            {
                service.URLFriendlyName = service.Name.ToLower().Replace(" ", "-");

                var URLFriendlyName = await _context.Services.FirstOrDefaultAsync(s => s.URLFriendlyName == service.URLFriendlyName);

                if(URLFriendlyName != null)
                {
                    ModelState.AddModelError("", "The product already exists");
                    return View(service);
                }

                if(service.ImageUpload != null)
                {
                    string uploadsDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/services");
                    string imageName = Guid.NewGuid().ToString() + "_" + service.ImageUpload.FileName;

                    string filePath = Path.Combine(uploadsDir, imageName);

                    FileStream fs = new FileStream(filePath, FileMode.Create);
                    await service.ImageUpload.CopyToAsync(fs);
                    fs.Close();

                    service.Image = imageName;
                }

                _context.Add(service);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Послугу було успішно створено!";

                return RedirectToAction("Index");
            }

            return View(service);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(long id)
        {
            Service service = await _context.Services.FindAsync(id);
            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name", service.CategoryId);

            return View(service);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id,Service service)
        {
            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name", service.CategoryId);
            
            if (ModelState.IsValid)
            {
                service.URLFriendlyName = service.Name.ToLower().Replace(" ", "-");

                var URLFriendlyName = await _context.Services.FirstOrDefaultAsync(s => s.URLFriendlyName == service.URLFriendlyName);

                if (URLFriendlyName != null)
                {
                    ModelState.AddModelError("", "The product already exists");
                    return View(service);
                }

                if (service.ImageUpload != null)
                {
                    string uploadsDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/services");
                    string imageName = Guid.NewGuid().ToString() + "_" + service.ImageUpload.FileName;

                    string filePath = Path.Combine(uploadsDir, imageName);

                    FileStream fs = new FileStream(filePath, FileMode.Create);
                    await service.ImageUpload.CopyToAsync(fs);
                    fs.Close();

                    service.Image = imageName;
                }

                _context.Update(service);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Інформацію про послугу оновлено!";
            }

            return View(service);
        }
        public async Task<IActionResult> Delete(long id)
        {
            Service service = await _context.Services.FindAsync(id);
            if (service == null)
            {
                return View("NotFound");
            }


            if (!string.Equals(service.Image, "noimage.jpg"))
            {
                string uploadsDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/services");
                string oldImagePath = Path.Combine(uploadsDir, service.Image);
                if(System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }

            }
            _context.Services.Remove(service);
            await _context.SaveChangesAsync();

            TempData["Success"] = "Послугу було видалено!";

            return RedirectToAction("Index");
        }
    }
}
