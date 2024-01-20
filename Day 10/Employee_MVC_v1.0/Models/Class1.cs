using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Employee_MVC_v2._0.Models
{
    public class Login
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
