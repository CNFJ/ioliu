using ioliu.data;
using ioliu.domain;
using ioliu.web.Sercers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing.Abstractions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ioliu.web
{
    public class HomeController : Controller
    {

        private readonly IResumeServers<SystemUser> inResumeRepository;


        public HomeController(IResumeServers<SystemUser> inResumeRepository)
        {
            this.inResumeRepository = inResumeRepository;
     
        }

        public InResumeRepository InResumeRepository { get; }

        public IActionResult Index()
        {


            if (inResumeRepository.GetAll().Count() > 0)
            {
                ViewData.Model = inResumeRepository.GetAll();

            }
            return View();

        }
        [HttpPost]
        public async Task< IActionResult> UPFile(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);
            var filess = Request.Form.Files;
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    var filePath = Path.Combine("C:\\pic\\",Path.GetRandomFileName()+".jpg");

                    using (var stream = System.IO.File.Create(filePath))
                    {
                        
                        await formFile.CopyToAsync(stream);
                        //Path.GetTempFileName(filePath);
                            
                    }
                }
               
            }

            return Ok(new { count=files.Count,size});
        }
        [HttpGet]
        public IActionResult UPFile()
        {
            return View();
        }
        public IActionResult Albums()
        {
            return View();
        }
        
    }
}

