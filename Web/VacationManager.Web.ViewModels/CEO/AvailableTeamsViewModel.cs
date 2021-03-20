namespace VacationManager.Web.ViewModels.CEO
{
    using System.Collections.Generic;

    public class AvailableTeamsViewModel
    {
        public string CustomerId { get; set; }

        public IEnumerable<AvailableTeamViewModel> AvailableTeams { get; set; }
    }
}
