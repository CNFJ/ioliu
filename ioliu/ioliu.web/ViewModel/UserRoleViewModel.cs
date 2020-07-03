using ioliu.domain;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ioliu.web.ViewModel
{
    public class UserRoleViewModel
    {
        public UserRoleViewModel()
        {
            Users = new List<SystemUser>();
        }

        public string UserId { get; set; }
        public string RoleID { get; set; }
        public List<SystemUser> Users { get; set; }
    }
}
