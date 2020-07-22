using ioliu.data;
using ioliu.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ioliu.web.Sercers
{
    public class InBlogRepository : IBlogServers<Blog>
    {
        private readonly IoliuContext ioliuContext;

        public InBlogRepository(IoliuContext ioliuContext)
        {
            this.ioliuContext = ioliuContext;
        }

        public Blog AddBlog(Blog newModel)
        {
            var result = ioliuContext.blogs.Add(newModel).State;
            ioliuContext.SaveChanges();
            return newModel;
        }

        public Blog EditBlog(Blog newModel)
        {
            var result = ioliuContext.blogs.Update(newModel).State;

            return newModel;
        }

        public IEnumerable<Blog> GetBlogs()
        {
            var blogs = ioliuContext.blogs.ToList();
            return blogs;
        }
    }
}
