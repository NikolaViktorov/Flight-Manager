namespace Project_Flight_Manager.Services.Contracts
{
    using Project_Flight_Manager.ViewModels.Flights;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IFlightsService
    {
        public Task<List<FlightViewModel>> GetFlights(int count, string filter);

        public Task<FlightDetailsViewModel> GetFlight(string flightId);
    }
}
