using ioliu.data;
using ioliu.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ioliu.web.Sercers
{
    public class InWorkRepository : IWorkServers<Work>
    {
        private readonly IoliuContext ioliuContext;

        public InWorkRepository(IoliuContext ioliuContext)
        {
            this.ioliuContext = ioliuContext;
        }

        public IEnumerable<Work> GetAll()
        {
            return ioliuContext.works.ToList();
        }

        public Work GetID(int id)
        {
            return ioliuContext.works.Find(id);
        }

        public Work Add(Work work)
        {
            ioliuContext.works.Add(work);
            ioliuContext.SaveChanges();
            return work;

        }
    }
}
