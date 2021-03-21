namespace VacationManager.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using VacationManager.Data;
    using VacationManager.Data.Models.Models;
    using VacationManager.Services.Data.Contracts;
    using VacationManager.Web.ViewModels.Teams;

    public class TeamsService : ITeamsService
    {
        private readonly ApplicationDbContext db;

        public TeamsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task CreateTeam(CreateTeamInputModel input)
        {
            var leader = await this.db.Users.FirstOrDefaultAsync(u => u.Id == input.LeaderId);

            var team = new Team()
            {
                Name = input.Name,
                Leader = leader as CEO,
                LeaderId = leader.Id,
            };

            leader.Team = team;
            leader.TeamId = team.TeamId;
            await this.db.Teams.AddAsync(team);
            await this.db.SaveChangesAsync();
        }

        public async Task<ICollection<TeamViewModel>> GetAllTeams()
        {
            // Add paging and get of certian count of teams
            var teams = await this.db.Teams.Select(t => new TeamViewModel()
            {
                TeamId = t.TeamId,
                CurrentProjectName = t.Project.Name,
                Name = t.Name,
                LeaderName = t.Leader.FirstName + " " + t.Leader.LastName,
                EmployeesCount = t.Employees.Count,
            }).ToListAsync();

            return teams;
        }

        public async Task<TeamDetailsViewModel> GetTeam(string teamId)
        {
            var team = await this.db.Teams.Include(t => t.Leader).Include(t => t.Project).Include(t => t.Employees).FirstOrDefaultAsync(t => t.TeamId == teamId);

            return new TeamDetailsViewModel()
            {
                TeamId = teamId,
                Name = team.Name,
                Leader = new TeamLeaderViewModel()
                {
                    Email = team.Leader.Email,
                    FullName = team.Leader.FirstName + " " + team.Leader.LastName,
                },
                Employees = team.Employees.Select(e => new TeamEmployeeViewModel()
                {
                    Email = e.Email,
                    FullName = e.FirstName + " " + e.LastName,
                }).ToList(),
                Project = new TeamProjectViewModel()
                {
                    Name = team.Project.Name,
                    Description = team.Project.Description,
                },
            };
        }
    }
}
