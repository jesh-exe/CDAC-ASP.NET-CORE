using System.ComponentModel.DataAnnotations;

namespace EmployeeMVC.Models
{
    public class Employee
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "City is Required")]
        public string City { get; set; }

        [Required(ErrorMessage = "Address is Required")]
        public string Address { get; set; }


    }
}
