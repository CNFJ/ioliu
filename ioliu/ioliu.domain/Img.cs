using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ioliu.domain
{
   public class Img
    {
        [Required]
        public int id { get; set; }
        [Required]
        [Display(Name ="名称")]
        public string imgName { get; set; }
        [Required]
        public string imgPath { get; set; }
        
        public string GroupName { get; set; }

    }
}
