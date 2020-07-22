using ioliu.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ioliu.web.Sercers
{
    public interface IBlogServers<T> where T :class
    {
       IEnumerable< Blog> GetBlogs();
         Blog AddBlog(T newModel);
        Blog EditBlog(T newModel);
    }
}
