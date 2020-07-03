using ioliu.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ioliu.web.ViewModel
{
    public class UserEditViewModel:SystemUser
    {
        public List<string> Claims { get; set; }
    }
}
