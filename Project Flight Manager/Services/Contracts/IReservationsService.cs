using Project_Flight_Manager.ViewModels.Reservations;
using System.Threading.Tasks;

namespace Project_Flight_Manager.Services.Contracts
{
    public interface IReservationsService
    {
        public Task CreateReservation(ReservationInputModel input);

        public Task<ReservationDetailsViewModel> ReservationDetails(string reservationId);
        Task EditReservation(ReservationEditInputModel reservationDataModel);
    }
}
