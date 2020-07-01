
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace ioliu.domain
{
    public class SystemUser:IdentityUser
    {
        public SystemUser(){
            Educations = new List<Education>();
            Works = new List<Work>();
}
        
        public string PassWord { get; set; }
       
        public string LoginName { get; set; }
        [Display(Name ="状态")]
        public string State { get; set; }
        [Display(Name ="创建时间")]
        public DateTime CreateTime { get; set; }
        [Display(Name ="登录时间")]
        public DateTime UpdateTime { get; set; }
        [Display(Name ="性别")]
        public int Sex { get; set; }
        [Display(Name ="年龄")]
        public sex Age { get; set; }
        [Display(Name ="出生日期")]
        public DateTime Birth { get; set; }
        [Display(Name ="地址")]
        public string Address { get; set; }
        [Display(Name ="电话号码"),DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Display(Name ="身份证号码")]
        public string IDCard { get; set; }
        [Display(Name ="民族")]
        public string Nation { get; set; }
        [Display(Name = "备注")]
        public string Remark { get; set; }
       
        public List<Education> Educations { get; set; }
        public List<Work> Works { get; set; }

       public enum sex
        {
            男=1,
            女=2
        }
    }
}
