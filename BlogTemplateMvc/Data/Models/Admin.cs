using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogTemplateMvc.Data.Models
{
    public class Admin
    {
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Username { get; set; }
    }
}