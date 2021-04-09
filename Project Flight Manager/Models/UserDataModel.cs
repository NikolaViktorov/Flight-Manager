using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Project_Flight_Manager.Models
{
    public class UserDataModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter your username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Enter your password"), Range(5,10)]
        public string Password  { get; set; }
        [Required(ErrorMessage = "Enter your email adress"), EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter your First name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Enter your Last name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Enter your EGN"), Range (10,10)]
        public int EGN { get; set; }
        [Required(ErrorMessage = "Enter your adress")]
        public string Adress { get; set; }
        [Required(ErrorMessage = "Enter your Phone number"), Phone]
        public int TelNumber { get; set; }
    }
}
