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
    [Authorize(Policy ="仅限管理员")]
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
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="roleAddModel"></param>
        /// <returns></returns>
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
        public async Task< IActionResult> EditRole(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return RedirectToAction("Index");
            }
            var roleEditViewModel = new RoleEditViewModel
            {
                Id = id,
                RoleName = role.Name,
                Users = new List<string>()
            };
            var users = await userManager.Users.ToListAsync();
            foreach(var user in users)
            {
                if(await userManager.IsInRoleAsync(user, role.Name))
                {
                    roleEditViewModel.Users.Add(user.UserName);
                }
            }
            return View(roleEditViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> EditRole(RoleEditViewModel roleEditViewModel)
        {
            var role = await roleManager.FindByIdAsync(roleEditViewModel.Id);
            if (role != null)
            {
                role.Name = roleEditViewModel.RoleName;
                var result = await roleManager.UpdateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(string.Empty, "更新角色时出错");
                return View(roleEditViewModel);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await roleManager.FindByNameAsync(id);
            if (role != null)
            {
                var result = await roleManager.DeleteAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(string.Empty, "删除角色时出错");
            }
            ModelState.AddModelError(string.Empty, "该角色不存在");
            return View("Index");

        }

        public async Task<IActionResult> AddUserToRole(string roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                return RedirectToAction("Index");
            }
            var vm = new UserRoleViewModel
            {
                RoleID = role.Id
            };
            var users = await userManager.Users.ToListAsync();
            foreach(var user in users)
            {
                if(!await userManager.IsInRoleAsync(user, role.Name))
                {
                    vm.Users.Add(user);
                }
            }
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> AddUserToRole(UserRoleViewModel userRoleViewModel)
        {
            var user = await userManager.FindByIdAsync(userRoleViewModel.UserId);
            var role = await roleManager.FindByIdAsync(userRoleViewModel.RoleID);
            if(user!=null && role != null)
            {
                var result = await userManager.AddToRoleAsync(user, role.Name);
                if (result.Succeeded)
                {
                    return RedirectToAction("EditRole",new { id=role.Id});
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(userRoleViewModel);
            }
            ModelState.AddModelError(string.Empty, "用户或角色未找到");
            return View(userRoleViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> RemoveUserRole(UserRoleViewModel userRoleViewModel)
        {
            var user = await userManager.FindByIdAsync(userRoleViewModel.UserId);
            var role = await roleManager.FindByNameAsync(userRoleViewModel.RoleID);
            if (user != null)
            {
                if(await userManager.IsInRoleAsync(user, role.Id))
                {
                var result=  await  userManager.RemoveFromRoleAsync(user,userRoleViewModel.RoleID);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("EditRole", new { id = role.Id });
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                    
                    
                }
                return RedirectToAction("EditRole", new { id = userRoleViewModel.RoleID });
            }
            ModelState.AddModelError(string.Empty, "用户或角色未找到");
            return View(userRoleViewModel);

        }
    }
}
