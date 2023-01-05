using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsClub.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SportsClub.Components
{
    public class CategoriesViewComponent : ViewComponent
    {
        private readonly SportsClubContext _context;
        public CategoriesViewComponent(SportsClubContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync() => View(await _context.Categories.ToListAsync());
    }
}
