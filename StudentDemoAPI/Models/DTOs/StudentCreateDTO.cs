using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentDemoAPI.Models.DTOs
{
    public class StudentCreateDTO
    {
        [Required(ErrorMessage = "Enter first name!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Enter last name!")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Enter correct email format!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter phone number!")]
        public string PhoneNumber { get; set; }
    }
}
