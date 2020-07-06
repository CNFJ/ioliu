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
using ioliu.web.ViewModel;
using ioliu.web.Model;
using ioliu.web.Sercers;

namespace ioliu.web.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserManager<SystemUser> userManager;
        private readonly ISystemUserServers<SystemUser> systemUserServers;

        public UserController(UserManager<SystemUser> userManager,ISystemUserServers<SystemUser> systemUserServers) 
        {
            this.userManager = userManager;
            this.systemUserServers = systemUserServers;
        }

        public   IActionResult Index()
        {
            var user =  userManager.Users.ToList();
            return View(user);
        }
        public async Task<IActionResult> EditUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user == null)
            {
                return RedirectToAction("Index");
            }
            var claims = await userManager.GetClaimsAsync(user);
            var vm = new UserEditViewModel
            {
                UserId=user.Id,
                Birth=user.Birth,
                UserName=user.UserName,
                Sex=user.Sex,
                Age=user.Age,
                Address=user.Address,
                Phone=user.Phone,
                IDCard=user.IDCard,
                Nation=user.Nation,
                Claims = claims.Select(x => x.Value).ToList()
            };
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> EditUser(UserEditViewModel userEditViewModel)
        {
            var user = await userManager.FindByIdAsync(userEditViewModel.Id);
            if (user != null)
            {
                user.UserName = userEditViewModel.UserName;
                user.Birth = userEditViewModel.Birth;
                user.Phone = userEditViewModel.Phone;
                user.Address = userEditViewModel.Address;
                
                var result =await userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach(var erroer in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, erroer.Description);
                    }
                    return View(userEditViewModel);
                }
            }
            return View(userEditViewModel);

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
        public async Task<IActionResult> ManageClaims(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return RedirectToAction("Index");
            }
            var vm = new ManageViewModel
            {
                UserId = userId,
                AllClaims=ClaimTypes.AllClaimTypeList
            };
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> ManageClaims(ManageViewModel manageViewModel)
        {

            var user = await userManager.FindByIdAsync(manageViewModel.UserId);
            if (user == null)
            {
                return RedirectToAction("Index");
            }
            var claim = new IdentityUserClaim<string>
            {
                ClaimType = manageViewModel.ClaimId,
                ClaimValue = manageViewModel.ClaimId
            };
            user.Claims.Add(claim);
            var result = await userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("EditUser", new { id = manageViewModel.UserId });
            }
            ModelState.AddModelError(string.Empty, "Claims错误");
            return View(manageViewModel);
        }

    }
}
