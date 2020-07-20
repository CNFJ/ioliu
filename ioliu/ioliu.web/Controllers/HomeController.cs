using ioliu.domain;
using ioliu.web.Sercers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ioliu.web
{
    public class HomeController : Controller
    {

        private readonly ISystemUserServers<SystemUser> inResumeRepository;
        private readonly IWorkServers<Work> workServers;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IImgServers<Img> imgServers;

        public HomeController(ISystemUserServers<SystemUser> inResumeRepository,IWorkServers<Work> workServers,IHostingEnvironment hostingEnvironment,IImgServers<Img> imgServers)
        {
            this.inResumeRepository = inResumeRepository;
            this.workServers = workServers;
            this.hostingEnvironment = hostingEnvironment;
            this.imgServers = imgServers;
        }

      

        public IActionResult Index()
        {


         
            return View();

        }
       
        public IActionResult Index_v1()
        {


           
            return View();

        }
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Resume()
        {
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> UPFile(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);
            var filess = Request.Form.Files;
            try {
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    var pathroot = hostingEnvironment.WebRootPath;
                    var fileNmae = Path.GetRandomFileName();
                    var pathFile= "\\static\\img\\"+ fileNmae + ".jpg";
                    var filePath = Path.Combine(pathroot + pathFile);

                    using (var stream = System.IO.File.Create(filePath))
                    {
                        
                        await formFile.CopyToAsync(stream);
                        //Path.GetTempFileName(filePath);
                            
                    }
                    var imgmdeol = new Img
                    {
                        imgName = fileNmae,
                        imgPath=pathFile,
                        GroupName="Test"
                    };
                    await imgServers.AddImg(imgmdeol);
                    
                }
               
            }
            }catch(Exception ex)
            {
                return View(ex.Message);
            }

            return View();
        }
        [HttpGet]
        public IActionResult UPFile()
        {
            var imgModel = imgServers.GetImgAll();
            return View(imgModel);
        }
        public IActionResult Albums()
        {
            var imgModel = imgServers.GetImgAll();
            return View(imgModel);
        }
        
    }
}

