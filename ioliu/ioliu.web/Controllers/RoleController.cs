using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ioliu.domain;
using ioliu.web.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ioliu.web.Controllers
{
    [Authorize]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<SystemUser> userManager;

        public RoleController(UserManager<SystemUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }
       
        public async Task< IActionResult> Index()
        {
            var roles = await roleManager.Roles.ToListAsync();
            return View(roles);
        }
        public IActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(RoleAddModel roleAddModel)
        {

            if (!ModelState.IsValid)
            {
                return View(roleAddModel);
            }
            var role = new IdentityRole
            {
                Name = roleAddModel.RoleName
            };
            var result =await roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            foreach(var erro in result.Errors)
            {
                ModelState.AddModelError(string.Empty,erro.Description);
            }
            return View(roleAddModel);
        }
    }
}
