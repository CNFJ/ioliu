using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;

namespace ioliu.domain
{
   public class Blog_Comment
    {
        [Required]
        [Key]
        public int Id { get; set; }
     
        
        [Required]
        [Display(Name = "评论时间")]
        public string CommentAddTime { get; set; }
        [Required]
        [Display(Name = "评论修改时间")]
        public DateTime CommentModificationTime { get; set; }
        [Required]
        [Display(Name = "评论添加人")]
        public string CommentAddUser { get; set; }
        [Required]
        [Display(Name = "评论内容")]
        public string CommentContent { get; set; }
        [Required]
        [Display(Name = "点赞数")]
        public int CommentLike { get; set; }
        [Required]
        [Display(Name ="评论文章ID")]
        public int Blog_Id { get; set; }
        [Required]
        [Display(Name ="父评论ID")]
        public int Blog_Comment_ParentId { get; set; }
    }
}
