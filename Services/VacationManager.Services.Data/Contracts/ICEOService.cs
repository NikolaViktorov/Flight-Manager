namespace VacationManager.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using VacationManager.Web.ViewModels.CEO;

    public interface ICEOService
    {
        public Task<ICollection<CustomerViewModel>> GetAll();

        public Task DeleteCustomerAccount(string customerId);

        public Task<CustomerDetailsViewModel> GetCustomer(string customerId);
    }
}
