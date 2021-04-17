using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Project_Flight_Manager.Models
{
    public class FlightDataModel
    {
        public FlightDataModel()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Reservations = new HashSet<ReservationDataModel>();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        public int AirlineID { get; set; }

        [Required]
        public string AirlineName { get; set; }

        [Required]
        public string FromLocation { get; set; }

        [Required]
        public string ToLocation { get; set; }

        public DateTime DepatureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        [Required]
        public string PilotName { get; set; }

        [Required]
        public int Capacity { get; set; }

        [Required]
        public int BusinessCapacity { get; set; }

        public virtual ICollection<ReservationDataModel> Reservations { get; set; }
    }
}
