using Project_Flight_Manager.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Flight_Manager.ViewModels.Reservations
{
    public class ReservationUserViewModel
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Ticket Type")]
        public TicketType TicketType { get; set; }
    }
}
