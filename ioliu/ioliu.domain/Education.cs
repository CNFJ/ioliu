using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ioliu.domain
{
   public class Education
    {
        public int id { get; set; }
        [Display(Name = "身份证号码")]
        public string IDCard { get; set; }
        [Display(Name ="层次")]
        public string arrangement { get; set; }
        [Display(Name = "学制")]
        public string SchoolSystem { get; set; }
        [Display(Name = "入学日期")]
        public DateTime StartDate { get; set; }
        [Display(Name = "毕（结）业日期")]
        public DateTime EndDate { get; set; }
        [Display(Name = "学校名称")]
        public string SchoolName { get; set; }
        [Display(Name ="专业")]
        public string Major { get; set; }
        [Display(Name = "学历类别")]
        public string EduType { get; set; }
        [Display(Name = "学习形式")]
        public string EduForm { get; set; }
        [Display(Name = "毕(结)业")]
        public string EduBJ { get; set; }
        [Display(Name = "校（院）长姓名")]
        public string EduName { get; set; }
        [Display(Name = "证书编号")]
        public string EduCard { get; set; }
        [Display(Name = "主修课程")]
        public string Curriculum { get; set; }
        
    }
}
