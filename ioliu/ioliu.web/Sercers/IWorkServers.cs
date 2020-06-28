using ioliu.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ioliu.web.Sercers
{
    public interface IWorkServers<T> where T:class
    {
        IEnumerable<T> GetAll();

        Work GetID(int id);
        Work Add(T newModel);
    }
}
