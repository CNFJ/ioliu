using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ioliu.domain
{
   public class Blog_Type
    {
        [Required]
        [Key]
        public int id { get; set; }
        public string Blog_Type_Name { get; set; }
        public string Blog_Type_Alias { get; set; }
        public string Blog_Type_Context { get; set; }
        public int Blog_Type_ParentId { get; set; }
    }
}
