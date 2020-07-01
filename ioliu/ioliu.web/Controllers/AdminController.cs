using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ioliu.data;
using ioliu.domain;
using ioliu.web.Sercers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ioliu.web.Controllers
{
    public class AdminController : Controller
    {
      
        private readonly ISystemUserServers<SystemUser> systemUserServers;

        public AdminController(ISystemUserServers<SystemUser> systemUserServers)
        {
           
            this.systemUserServers = systemUserServers;
        }
        [Authorize]
        public IActionResult Index()
        {
            

            return View();
        }

        public IActionResult PersonalInformation()
        {
            if (systemUserServers.GetByUserName("df") != null)
            {
                ViewData.Model = systemUserServers.GetByUserName("df");
            }
            return View();
        }
    }
}
