using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ioliu.web.Controllers
{
    public class BlogController:Controller
    {
        public  IActionResult Index()
        {
            return View();
        }
        public async IActionResult Edit()
        {

        }
    }
}
