namespace VacationManager.Data.Models.Models
{
    using System;
    using System.Collections.Generic;

    public class Team
    {
        public Team()
        {
            this.TeamId = Guid.NewGuid().ToString();
            this.Employees = new HashSet<ApplicationUser>();
        }

        public string TeamId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<ApplicationUser> Employees { get; set; }

        public CEO Leader { get; set; }

        public string LeaderId { get; set; }

        public Project Project { get; set; }

        public string ProjectId { get; set; }
    }
}
