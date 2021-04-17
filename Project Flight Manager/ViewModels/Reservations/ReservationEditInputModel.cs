using Project_Flight_Manager.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Flight_Manager.ViewModels.Reservations
{
    public class ReservationEditInputModel
    {
        [Required(ErrorMessage = "Enter your First name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Enter your Middle name")]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Enter your Last name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Enter your EGN")]
        public int EGN { get; set; }

        [Required(ErrorMessage = "Enter your Phone number")]
        [Display(Name = "Phone Number")]
        public int TelNumber { get; set; }

        [Required(ErrorMessage = "Enter your nationality name")]
        public string Nationality { get; set; }

        [Required(ErrorMessage = "Enter your Ticket type")]
        [Display(Name = "Ticket Type")]
        public TicketType TicketType { get; set; }

        public string ReservationId { get; set; }
    }
}
