using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogTemplateMvc.Data.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "You must enter your name to proceed!")]
        [MaxLength(70, ErrorMessage = "Sorry but your name is too long, please enter only your first name!")]
        [RegularExpression(@"^[\p{L} \.'\-]+$", ErrorMessage = "Invalid name!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "You must enter your email to proceed!")]
        [RegularExpression(
            @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z"
            , ErrorMessage = "Invalid email address!")]
        public string Email { get; set; }

        public string MessageText { get; set; }

        public DateTime SentOn { get; set; }
    }
}