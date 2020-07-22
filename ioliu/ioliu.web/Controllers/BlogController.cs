using ioliu.domain;
using ioliu.web.Sercers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ioliu.web.Controllers
{
    public class BlogController:Controller
    {
        private readonly IBlogServers<Blog> blogServers;

        public BlogController(IBlogServers<Blog> blogServers)
        {
            this.blogServers = blogServers;
        }

        public  IActionResult Index()
        {
            return View();
        }
        public  IActionResult Edit()
        {
            return View();
        }
        public IActionResult AddBlog()
        {
           
            return View();
        }
        [HttpPost]
        public IActionResult AddBlog(Blog blog)
        {


            blog.BlogAddTime = DateTime.Now;
            blog.BlogModificationTime = DateTime.Now;
            blog.BlogAddUser = "df";
            blogServers.AddBlog(blog);
            return View(blog);
        }
    }
}
