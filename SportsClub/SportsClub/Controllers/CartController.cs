using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.EntityFrameworkCore;
using SportsClub.Areas.Identity.Data;
using SportsClub.Data;
using SportsClub.Models;
using SportsClub.Models.Order;
using SportsClub.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace SportsClub.Areas.Admin.Controllers
{
    public class CartController : Controller
    {
        [BindProperty]
        public CartViewModel CartVM { get; set; }
        private readonly SportsClubContext _context;
        private readonly UserManager<AppUser> _userManager;
        public CartController(SportsClubContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            CartVM = new CartViewModel()
            {
                OrderHeader = new OrderHeader(),
                CartItems = new List<CartItem>()
            };
        }
    
        public async Task<IActionResult> Index()
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            CartVM.CartItems = cart;
            CartVM.GrandTotal = cart.Sum(x => x.Total);
            CartVM.OrderHeader.User = await _userManager.FindByNameAsync(User.Identity.Name);
            CartVM.OrderHeader.UserId = CartVM.OrderHeader.User.Id;

            return View(CartVM);
        }
        public async Task<IActionResult> Add(long id)
        {
            Service service = await _context.Services.FindAsync(id);

            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            CartItem cartItem = cart.Where(s => s.ProductId == id).FirstOrDefault();

            if (cartItem == null)
            {
                cart.Add(new CartItem(service));
            }
            else
            {
                cartItem.Quantity += 1;
            }

            HttpContext.Session.SetJson("Cart", cart);

            TempData["Success"] = "Послугу успішно додано!";

            return Redirect(Request.Headers["Referer"].ToString());
        }
        public async Task<IActionResult> Decrease(long id)
        {

            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");

            CartItem cartItem = cart.Where(s => s.ProductId == id).FirstOrDefault();

            if (cartItem.Quantity > 1)
            {
                --cartItem.Quantity;
            }
            else
            {
                cart.RemoveAll(x => x.ProductId == id);
            }

            if(cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            }

            TempData["Success"] = "Послугу було видалено!";

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Remove(long id)
        {

            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");

            cart.RemoveAll(x => x.ProductId == id);

            if (cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            }

            TempData["Success"] = "Послугу було видалено!";

            return RedirectToAction("Index");
        }
        public IActionResult Clear()
        {
            HttpContext.Session.Remove("Cart");
   
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveOrder()
        {
            if (HttpContext.Session.GetJson<List<CartItem>>("Cart") != null)
            {
                List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");

                CartVM.CartItems = cart;
                CartVM.GrandTotal = cart.Sum(x => x.Total);
                CartVM.OrderHeader.User = await _userManager.FindByNameAsync(User.Identity.Name);
                CartVM.OrderHeader.UserId = CartVM.OrderHeader.User.Id;
                CartVM.OrderHeader.OrderDate = DateTime.Now;
                CartVM.OrderHeader.Status = "Submitted";
                CartVM.OrderHeader.ServiceCount = CartVM.CartItems.Count;
                
                if (!ModelState.IsValid)
                {
                    return View("Index", CartVM);
                }

                _context.OrderHeaders.Add(CartVM.OrderHeader);
                _context.SaveChanges();

                foreach (var item in CartVM.CartItems)
                {
                    OrderDetails orderDetails = new OrderDetails
                    {
                        ServiceId = item.ProductId,
                        OrderHeaderId = CartVM.OrderHeader.Id,
                        ServiceName = item.ProductName,
                        Price = item.Price,
                        Quantity = item.Quantity,
                    };

                    _context.OrderDetails.Add(orderDetails);
                    _context.SaveChanges();
                }

            }
 
            HttpContext.Session.Remove("Cart");

            TempData["Success"] = "Запит на отримання послуг успішно створено!";

            return RedirectToAction("OrderConfirmation", new {id = CartVM.OrderHeader.Id });
        }

        public IActionResult OrderConfirmation(int id)
        {
            return View(id);
        }
    }
}
