using ioliu.data;
using ioliu.domain;
using ioliu.web.Sercers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ioliu.web
{
    public class HomeController:Controller
    {

        private readonly IResumeServers<SystemUser> inResumeRepository;
        public HomeController(IResumeServers<SystemUser> inResumeRepository)
        {
            this.inResumeRepository = inResumeRepository;
        }
      

        public InResumeRepository InResumeRepository { get; }

        public IActionResult Index( )
        {
            
           
                  if (inResumeRepository.GetAll().Count()> 0)
                {
                    ViewData.Model = inResumeRepository.GetAll();

                }
                return View();
           
           
                
            }

           
           

        }
    }

