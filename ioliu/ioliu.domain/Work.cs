using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ioliu.domain
{
   public class Work
    {
        public int id { get; set; }
        [Display(Name = "身份证号码")]
        public string IDCard { get; set; }
        [Display(Name ="公司名称")]
        public string CompanyName { get; set; }
        [Display(Name = "工作内容")]
        public string WorkContent { get; set; }
        [Display(Name = "入职时间")]
        public DateTime WorkStart { get; set; }
        [Display(Name = "离职时间")]
        public DateTime WorkEnd { get; set; }
        [Display(Name = "职位")]
        public string Position { get; set; }
        
        public int SystemUserId { get; set; }
    }
}
