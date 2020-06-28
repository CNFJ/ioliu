using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ioliu.data;
using ioliu.domain;
using ioliu.web.Sercers;
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

        public IActionResult Index()
        {
            

            return View();
        }

        public IActionResult PersonalInformation()
        {
            if (systemUserServers.GetById(5) != null)
            {
                ViewData.Model = systemUserServers.GetById(5);
            }
            return View();
        }
    }
}
