using Microsoft.AspNetCore.Mvc;
using SportsClub.Data;
using SportsClub.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace SportsClub.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrdersController : Controller
    {
        private readonly SportsClubContext _context;
        public OrdersController(SportsClubContext context)
        {
            _context = context;
        }
        public void ChangeOrderStatus(int orderHeaderId, string status)
        {
            var order = _context.OrderHeaders.FirstOrDefault(o => o.Id == orderHeaderId);
            order.Status = status;
            _context.SaveChanges();
        }
        public IActionResult Index(string? status)
        {
            if (status == "approved")
            {
                return View(_context.OrderHeaders.Where(o => o.Status == "Approved").ToList());
            }
            else if(status == "pending")
            {
                return View(_context.OrderHeaders.Where(o => o.Status == "Submitted").ToList());
            }
            return View(_context.OrderHeaders.ToList());
        }
        public IActionResult Details(int id)
        {
            OrderViewModel orderVM = new OrderViewModel()
            {
                OrderHeader = _context.OrderHeaders.FirstOrDefault(o => o.Id == id),
                OrderDetails = _context.OrderDetails.Where(o => o.OrderHeaderId == id)
            };

            return View(orderVM);
        }

        public IActionResult Approve(int id)
        {
            var orderFromDb = _context.OrderHeaders.FirstOrDefault(o => o.Id == id);
            if (orderFromDb == null)
            {
                return NotFound();
            }
            ChangeOrderStatus(id, "Approved");
            return RedirectToAction("Index");
        }

        public IActionResult Reject(int id)
        {
            var orderFromDb = _context.OrderHeaders.FirstOrDefault(o => o.Id == id);
            if (orderFromDb == null)
            {
                return NotFound();
            }
            ChangeOrderStatus(id, "Rejected");
            return RedirectToAction("Index");
        }

        #region API Calls

        public IActionResult GetAllOrders()
        {
            return Json(new { data = _context.OrderHeaders.ToList() });
        }

        public IActionResult GetAllPendingOrders()
        {
            return Json(new { data = _context.OrderHeaders.Where(o => o.Status == "Submited").ToList() });
        }

        public IActionResult GetAllApprovedOrders()
        {
            return Json(new { data = _context.OrderHeaders.Where(o => o.Status == "Approved").ToList() });
        }

        #endregion

    }
}
