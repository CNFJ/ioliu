using ioliu.domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ioliu.web.Controllers
{
    public class AccountController:Controller
    {
        private readonly SignInManager<SystemUser> _signInManager;
        private readonly UserManager<SystemUser> _userManager;

        public AccountController(SignInManager<SystemUser> signInManager, UserManager<SystemUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(SystemUser systemUser)
        {
            if (!ModelState.IsValid)
            {
                return View(systemUser);
            }
            var user = await _userManager.FindByNameAsync(systemUser.UserName);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, systemUser.PasswordHash, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(systemUser);
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(SystemUser systemUser)
        {
            if (ModelState.IsValid)
            {
                var user = new SystemUser
                {
                    UserName = systemUser.UserName
                };
                var result = await _userManager.CreateAsync(user, systemUser.PasswordHash);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(systemUser);
        }
        public  async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index_v2", "Home");
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
