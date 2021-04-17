namespace Project_Flight_Manager.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Project_Flight_Manager.Services.Contracts;
    using Project_Flight_Manager.ViewModels.Administration;
    using System.Security.Claims;
    using System.Threading.Tasks;

    [Authorize(Roles = "Admin")]
    public class AdministrationController : Controller
    {
        private readonly IAdministrationService administrationService;

        public AdministrationController(IAdministrationService administrationService)
        {
            this.administrationService = administrationService;
        }

        public IActionResult AdminPanel()
        {
            return this.View();
        }

        public async Task<IActionResult> Users(int? pageNumber, string filter)
        {
            int pageSize = 10;

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var model = await this.administrationService.GetUsers(10, filter, userId);
            var pagedModel = await PaginatedList<UserViewModel>.CreateAsync(model, pageNumber ?? 1, pageSize);
            return this.View(pagedModel);
        }

        public async Task<IActionResult> DeleteUser(string id)
        {
            await this.administrationService.DeleteUser(id);
            return this.Redirect("/Administration/Users");
        }
    }
}
