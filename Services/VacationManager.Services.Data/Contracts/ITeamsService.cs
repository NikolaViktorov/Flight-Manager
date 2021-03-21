namespace VacationManager.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using VacationManager.Web.ViewModels.Teams;

    public interface ITeamsService
    {
        public Task<ICollection<TeamViewModel>> GetAllTeams();

        public Task<TeamDetailsViewModel> GetTeam(string teamId);

        public Task CreateTeam(CreateTeamInputModel input);
    }
}
