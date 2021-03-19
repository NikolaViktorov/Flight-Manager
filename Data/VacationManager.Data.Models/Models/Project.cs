namespace VacationManager.Data.Models.Models
{
    using System;
    using System.Collections.Generic;

    public class Project
    {
        public Project()
        {
            this.ProjectId = Guid.NewGuid().ToString();
            this.Teams = new HashSet<Team>();
        }

        public string ProjectId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Team> Teams { get; set; }
    }
}
