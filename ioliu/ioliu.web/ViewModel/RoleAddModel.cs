using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ioliu.web.ViewModel
{
    public class RoleAddModel:IdentityRole
    {
        [Required]
        [Display(Name="用户名")]
        public string RoleName { get; set; }
    }
}
