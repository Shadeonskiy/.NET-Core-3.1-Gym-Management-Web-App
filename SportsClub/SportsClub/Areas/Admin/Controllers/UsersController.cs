using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportsClub.Areas.Identity.Data;
using SportsClub.Data;
using SportsClub.Models;

namespace SportsClub.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        UserManager<AppUser> _userManager;

        public UsersController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: Users
        [HttpGet]
        public async Task<IActionResult> Index(string userSearch)
        {
            ViewData["Search"] = userSearch;
            if (userSearch == null)
            {
                return View(_userManager.Users.ToList());
            }
            var searchedUsers = _userManager.Users.Where(
                u => u.FirstName.Contains(userSearch) ||
                u.LastName.Contains(userSearch) ||
                u.UserName.Contains(userSearch) ||
                u.Email.Contains(userSearch));
            return View(searchedUsers.OrderByDescending(s => s.Id));
        }
        // GET: Users/Details/5
        public async Task<IActionResult> Details(string userId)
        {
            if (userId == null)
            {
                return View("NotFound");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return View("NotFound");
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create() => View();

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Username,FirstName,LastName,Email,Password,PhoneNumber")] User user)
        {
            if (ModelState.IsValid)
            {
                var new_user = new AppUser
                {
                    UserName = user.Username,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    PhoneNumber = user.PhoneNumber,
                    EmailConfirmed = true
                };
                var result = await _userManager.CreateAsync(new_user, user.Password);
                if (result.Succeeded)
                {
                    var default_role = _roleManager.FindByNameAsync("Користувач").Result;
                    if (default_role != null)
                    {
                        IdentityResult role_result = await _userManager.AddToRoleAsync(new_user, default_role.Name);
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return View("NotFound");
            }
            return View(user);
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string userId,  AppUser user)
        {
            AppUser updated_user = await _userManager.FindByIdAsync(userId);
            if (ModelState.IsValid)
            {
                if (updated_user != null)
                {
                    if (user.UserName != updated_user.UserName)
                    {
                        updated_user.UserName = user.UserName;
                    }
                    if (user.FirstName != updated_user.FirstName)
                    {
                        updated_user.FirstName = user.FirstName;
                    }
                    if (user.LastName != updated_user.LastName)
                    {
                        updated_user.LastName = user.LastName;
                    }
                    if (user.Email != updated_user.Email)
                    {
                        updated_user.Email = user.Email;
                    }
                    if (user.PhoneNumber != updated_user.PhoneNumber)
                    {
                        updated_user.PhoneNumber = user.PhoneNumber;
                    }
                    await _userManager.UpdateAsync(updated_user);
                }
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(string userId)
        {
            if (userId == null)
            {
                return View("NotFound");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return View("NotFound");
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View("NotFound");
            }
            else
            {
                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View("Index");
            }

        }
    }
}
