namespace VacationManager.Web.ViewModels.Teams
{
    using System.Collections.Generic;

    public class TeamDetailsViewModel
    {
        public string TeamId { get; set; }

        public string Name { get; set; }

        public TeamLeaderViewModel Leader { get; set; }

        public TeamProjectViewModel Project { get; set; }

        public ICollection<TeamEmployeeViewModel> Employees { get; set; }
    }
}
