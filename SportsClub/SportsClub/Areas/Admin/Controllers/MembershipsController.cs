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
    public class MembershipsController : Controller
    {
        private readonly SportsClubContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public MembershipsController(SportsClubContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Index(int p = 1)
        {
            return View(await _context.Memberships.OrderByDescending(s => s.Id)
                   .ToListAsync());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MembershipPlan membership)
        {
            if (ModelState.IsValid)
            {
                membership.Status = "Active";
                _context.Add(membership);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Новий абонемент успішно створено!";

                return RedirectToAction("Index");
            }

            return View(membership);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(long id)
        {
            var membership = await _context.Memberships.FindAsync(id);
            if (membership == null)
            {
                return View("NotFound");
            }

            return View(membership);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, MembershipPlan membership)
        {
            if (ModelState.IsValid)
            {
                membership.Status = "Active";
                _context.Update(membership);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Інформацію про абонемент успішно оновлено!";
                return RedirectToAction("Index");
            }

            return View(membership);
        }
        public async Task<IActionResult> Activate(long id)
        {
            var membership = await _context.Memberships.FindAsync(id);
            if (membership == null)
            {
                return View("NotFound");
            }

            membership.Status = "Active";

            _context.Update(membership);
            await _context.SaveChangesAsync();

            TempData["Success"] = "Абонемент успішно активовано!";
            return RedirectToAction("Edit", membership);
        }

        public async Task<IActionResult> Deactivate(long id)
        {
            var membership = await _context.Memberships.FindAsync(id);
            if (membership == null)
            {
                return View("NotFound");
            }


            membership.Status = "Deactivated";

            _context.Update(membership);
            await _context.SaveChangesAsync();

            TempData["Success"] = "Абонемент успішно деактивовано!";
            return RedirectToAction("Edit", membership);
        }
        public async Task<IActionResult> Delete(long id)
        {
            var membership = await _context.Memberships.FindAsync(id);
            if(membership == null)
            {
                return View("NotFound");
            }

            _context.Memberships.Remove(membership);
            await _context.SaveChangesAsync();

            TempData["Success"] = "Абонемент було видалено!";

            return RedirectToAction("Index");
        }
    }
}
