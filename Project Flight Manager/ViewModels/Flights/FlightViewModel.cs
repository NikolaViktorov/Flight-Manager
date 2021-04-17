using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Flight_Manager.ViewModels.Flights
{
    public class FlightViewModel
    {
        public string FlightId { get; set; }

        [Display(Name = "Airline Id")]
        public int AirlineID { get; set; }

        [Display(Name = "Airline Name")]
        public string AirlineName { get; set; }

        [Display(Name = "From")]
        public string FromLocation { get; set; }

        [Display(Name = "To")]
        public string ToLocation { get; set; }

        [Display(Name = "Departure Time")]
        public DateTime DepatureTime { get; set; }

        [Display(Name = "Arrival Time")]
        public DateTime ArrivalTime { get; set; }

        [Display(Name = "Pilot Name")]
        public string PilotName { get; set; }

        public int Capacity { get; set; }

        [Display(Name = "Business Capacity")]
        public int BusinessCapacity { get; set; }
    }
}
