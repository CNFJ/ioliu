using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ioliu.domain;
using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ioliu.web.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserManager<SystemUser> userManager;

        public UserController(UserManager<SystemUser> userManager)
        {
            this.userManager = userManager;
        }

        public   IActionResult Index()
        {
            var user =  userManager.Users.ToList();
            return View(user);
        }

        public IActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(SystemUser systemUser)
        {
            if (!ModelState.IsValid)
            {
                return View(systemUser);
            }
            var user = new SystemUser
            {
                UserName = systemUser.UserName,
                Sex=systemUser.Sex,
                Birth=systemUser.Birth,
                Address=systemUser.Address,
                Phone=systemUser.Phone,
                IDCard=systemUser.IDCard,
                Nation=systemUser.Nation

            };
            var result = await userManager.CreateAsync(user, systemUser.PassWord);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                foreach(IdentityError error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(systemUser);
        }
        [HttpPost]
        public async Task< IActionResult> DelUser(string id)
        {
            var user =await userManager.FindByIdAsync(id);
            if (user != null)
            {
                var result =await userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "删除用户发生错误");
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "用户不存在");
            }
            return View("Index");
        }
    }
}
