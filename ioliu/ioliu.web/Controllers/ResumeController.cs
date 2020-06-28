using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ioliu.domain;
using ioliu.web.Sercers;
using Microsoft.AspNetCore.Mvc;

namespace ioliu.web.Controllers
{
    public class ResumeController : Controller
    {
        private readonly ISystemUserServers<SystemUser> inResumeRepository;

        public ResumeController(ISystemUserServers<SystemUser> inResumeRepository)
        {
            this.inResumeRepository = inResumeRepository;
        }
        public IActionResult Index()
        {
            
            return View(inResumeRepository.GetAll());
        }
        [HttpGet]
        public IActionResult add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult add(SystemUser systemUser)
        {
            inResumeRepository.Add(systemUser);
            return RedirectToAction(nameof(HomeController.Index),nameof(HomeController));
        }
    }
}
