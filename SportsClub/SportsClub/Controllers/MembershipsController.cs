using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportsClub.Data;
using System.Linq;

namespace SportsClub.Controllers
{
    [AllowAnonymous]
    public class MembershipsController : Controller
    {
        private readonly SportsClubContext _context;
        public MembershipsController(SportsClubContext context)
        {
            _context = context;
        }
        public IActionResult Index(string? filter = "Місячний")
        {
            var memberships = _context.Memberships.Where(m => m.Period == filter || filter == null);
            return View(memberships);
        }
        public IActionResult Subscribe(long id)
        {
            var membership = _context.Memberships.FirstOrDefault(m => m.Id == id);

            if(membership == null)
            {
                return NotFound();
            }

            membership.TotalAmount++;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
