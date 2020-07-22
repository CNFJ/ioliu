using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ioliu.domain
{
   public class Blog
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="博客标题")]
        public string BlogName { get; set; }
        [Required]
        [Display(Name ="添加时间")]
        public DateTime BlogAddTime { get; set; }
        [Required]
        [Display(Name ="修改时间")]
        public DateTime BlogModificationTime { get; set; }
        [Required]
        [Display(Name ="添加人")]
        public string BlogAddUser { get; set; }
        [Required]
        [Display(Name ="内容")]
        public string BlogContent { get; set; }

        [Display(Name = "点赞数")]
        public int BlogLike { get; set; } = 0;

        [Display(Name = "回复数")]
        public int BlogReply { get; set; } = 0;

        [Display(Name = "浏览量")]
        public int BlogBrowse { get; set; } = 0;
        public string Tags { get; set; }
    }
}
