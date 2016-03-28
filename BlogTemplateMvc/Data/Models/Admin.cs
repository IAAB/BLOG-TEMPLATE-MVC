using System.ComponentModel.DataAnnotations;

namespace BlogTemplateMvc.Data.Models
{
    public class Admin
    {
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Username { get; set; }
    }
}