using ioliu.data;
using ioliu.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ioliu.web.Sercers
{
    public class InResumeRepository:IResumeServers<SystemUser>
    {
        private readonly IoliuContext _ioliuContext;
        private  List<SystemUser> _systemUsers=new List<SystemUser>();

        public InResumeRepository(IoliuContext ioliuContext)
        {
            _ioliuContext = ioliuContext;
        }

        public SystemUser Add(SystemUser systemUser)
        {
            systemUser.CreateTime = DateTime.Now;
            systemUser.UpdateTime = DateTime.Now;
            _ioliuContext.systemUsers.Add(systemUser);
            _ioliuContext.SaveChanges();
            return systemUser;
        }

        public IEnumerable<SystemUser> GetAll()
        {
            _systemUsers = _ioliuContext.systemUsers.ToList();
            return _systemUsers;
        }
        public SystemUser GetById(int id)
        {
            return _ioliuContext.systemUsers.Find(id);
        }
    }
}
