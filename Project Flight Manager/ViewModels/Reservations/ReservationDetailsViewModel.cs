using Project_Flight_Manager.Models.Enum;

namespace Project_Flight_Manager.ViewModels.Reservations
{
    public class ReservationDetailsViewModel
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public int EGN { get; set; }

        public int TelNumber { get; set; }

        public string Nationality { get; set; }

        public TicketType TicketType { get; set; }

        public string FlightName { get; set; }
    }
}
