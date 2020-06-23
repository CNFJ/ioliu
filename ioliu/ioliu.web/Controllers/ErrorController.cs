using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ioliu.web.Controllers
{
    public class ErrorController : Controller
    {
        [Route("error/404")]
        public IActionResult Error404()
        {
            return View();
        }
        [Route("error/{code:int}")]
        public IActionResult Error(int code)
        {
            return View();
        }
    }
}
