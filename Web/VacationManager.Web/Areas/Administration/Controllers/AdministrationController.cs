namespace VacationManager.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using VacationManager.Common;
    using VacationManager.Services.Data.Contracts;
    using VacationManager.Web.Controllers;
    using VacationManager.Web.ViewModels.Administration;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class CEOController : BaseController
    {
        private readonly IAdministrationService administrationService;

        public CEOController(IAdministrationService administrationService)
        {
            this.administrationService = administrationService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult AddCEO()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCEO(CEOInputModel input)
        {

            await this.administrationService.AddCEO(input);

            return this.Redirect("/Administration/Administration");
        }

        public IActionResult RemoveCEO()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> RemoveCEO(CEORemoveModel input)
        {

            await this.administrationService.RemoveCEO(input);

            return this.Redirect("/Administration/Administration");
        }
    }
}
