namespace VacationManager.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using VacationManager.Services.Data.Contracts;
    using VacationManager.Web.ViewModels.Teams;

    public class TeamsController : BaseController
    {
        private readonly ITeamsService teamsService;

        public TeamsController(ITeamsService teamsService)
        {
            this.teamsService = teamsService;
        }

        public async Task<IActionResult> AllTeams()
        {
            var viewModel = await this.teamsService.GetAllTeams();

            return this.View(viewModel);
        }

        public async Task<IActionResult> TeamDetails(string id)
        {
            var viewModel = await this.teamsService.GetTeam(id);

            return this.View(viewModel);
        }

        public IActionResult CreateTeam()
        {
            var viewModel = new CreateTeamInputModel()
            {
                LeaderId = this.User.FindFirstValue(ClaimTypes.NameIdentifier),
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeam(CreateTeamInputModel input)
        {
            await this.teamsService.CreateTeam(input);

            return this.Redirect("/Teams/AllTeams");
        }


    }
}
