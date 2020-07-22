using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ioliu.domain
{
   public class Blog_Tag
    {
        [Required]
        [Key]
        public int Id { get; set; }

        public string Blog_Tag_Name { get; set; }
        public string Blog_Tag_Alias { get; set; }
        public string Blog_Tag_Content { get; set; }
    }
}
