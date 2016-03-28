using System;
using System.ComponentModel.DataAnnotations;

namespace BlogTemplateMvc.Data.Models
{
    public class Post
    {
        //TODO Add Tags later

        [Key]
        public int Id { get; set; }

        [MaxLength(120,ErrorMessage ="Title should not be more than 120 charecters!")]
        [Required]
        public string Title { get; set; }

        [MaxLength(150,ErrorMessage = "Title should not be more than 150 charecters!")]
        public string Subtitle { get; set; }

        [Required]
        public string Content { get; set; }

        public byte[] Image { get; set; }

        public DateTime PostedOn { get; set; }
        
    }
}