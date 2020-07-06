using ioliu.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ioliu.web.ViewModel
{
    public class UserEditViewModel:SystemUser
    {
        public string UserId { get; set; }
        public string ClaimId { get; set; }
        public List<string> Claims { get; set; }
    }
}
