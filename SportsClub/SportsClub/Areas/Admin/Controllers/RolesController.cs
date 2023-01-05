using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using SportsClub.Areas.Identity.Data;
using System.Linq;
using System.Threading.Tasks;
using SportsClub.ViewModels;
using System.Collections.Generic;

namespace SportsClub.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RolesController : Controller
    {
        private RoleManager<IdentityRole> _roleManager;
        UserManager<AppUser> _userManager;
        public RolesController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public IActionResult Index() => View(_roleManager.Roles.ToList());
        public IActionResult Create() => View();
        [HttpPost]
        public async Task<IActionResult> Create(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(name));
                if (result.Succeeded)
                {
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
            return View(name);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                IdentityResult result = await _roleManager.DeleteAsync(role);
            }
            return RedirectToAction("Index");
        }

        public IActionResult UserList() => View(_userManager.Users.ToList());

        public async Task<IActionResult> Edit(string userId)
        {
            // отримуємо користувача
            AppUser user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                // отримуємо список ролей користувача
                var userRoles = await _userManager.GetRolesAsync(user);
                var allRoles = _roleManager.Roles.ToList();
                ChangeRoleViewModel model = new ChangeRoleViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    UserEmail = user.Email,
                    UserRoles = userRoles,
                    AllRoles = allRoles
                };
                return View(model);
            }

            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(string userId, List<string> roles)
        {
            // отримуємо користувача
            AppUser user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                // отримуємо ролі користувача
                var userRoles = await _userManager.GetRolesAsync(user);
                // отримуємо усі ролі
                var allRoles = _roleManager.Roles.ToList();
                // отримуємо списко ролей, які були додані
                var addedRoles = roles.Except(userRoles);
                // отримуємо списко ролей, які були видалені
                var removedRoles = userRoles.Except(roles);

                await _userManager.AddToRolesAsync(user, addedRoles);

                await _userManager.RemoveFromRolesAsync(user, removedRoles);

                return RedirectToAction("UserList");
            }

            return NotFound();
        }
    }
}
