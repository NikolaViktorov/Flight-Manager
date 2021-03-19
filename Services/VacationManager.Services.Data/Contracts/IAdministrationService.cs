namespace VacationManager.Services.Data.Contracts
{
    using System.Threading.Tasks;

    using VacationManager.Web.ViewModels.Administration;

    public interface IAdministrationService
    {
        public Task AddCEO(CEOInputModel input);

        public Task RemoveCEO(CEORemoveModel input);
    }
}
