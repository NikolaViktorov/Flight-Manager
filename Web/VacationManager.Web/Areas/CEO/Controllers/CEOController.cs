namespace VacationManager.Web.Areas.CEO.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using VacationManager.Common;
    using VacationManager.Services.Data.Contracts;
    using VacationManager.Web.Controllers;

    [Authorize(Roles = GlobalConstants.CEORoleName)]
    [Area("CEO")]
    public class CEOController : BaseController
    {
        private readonly ICEOService cEOService;

        public CEOController(ICEOService cEOService)
        {
            this.cEOService = cEOService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public async Task<IActionResult> CustomerList()
        {
            var viewModel = await this.cEOService.GetAll();

            return this.View(viewModel);
        }

        public async Task<IActionResult> CustomerDetails(string customerId)
        {
            var viewModel = await this.cEOService.GetCustomer(customerId);

            return this.View(viewModel);
        }

        public async Task<IActionResult> RemoveCustomer(string customerId)
        {
            await this.cEOService.DeleteCustomerAccount(customerId);

            return this.Redirect("/CEO/CEO");
        }

        public async Task<IActionResult> AvailableTeams(string customerId)
        {
            var viewModel = await this.cEOService.GetAvailableTeams(customerId);
            // TRY
            return this.View(viewModel);
        }

        public async Task<IActionResult> AddClientToTeam(string customerId, string teamId)
        {
            await this.cEOService.AddClientToTeam(customerId, teamId);
            // TRY
            return this.Redirect("/CEO/CEO/CustomerList");
        }
    }
}
