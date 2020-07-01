using ioliu.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ioliu.web.Sercers
{
    public interface ISystemUserServers<T> where T:class
    {
         SystemUser GetByUserName(string userName);
         IEnumerable<T> GetAll();

         SystemUser Add(T newModel);

    }
}
