using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BlogTemplateMvc.Data.Models
{
    public class Post
    {
        //TODO Add Tags later

        [Key]
        public int Id { get; set; }

        [MaxLength(70,ErrorMessage ="Title should not be more than 70 charecters!")]
        [Required]
        public string Title { get; set; }

        [MaxLength(70,ErrorMessage = "Title should not be more than 70 charecters!")]
        public string Subtitle { get; set; }

        [Required]
        public string Content { get; set; }

        public byte[] Image { get; set; }

        public DateTime PostedOn { get; set; }
        
    }
}