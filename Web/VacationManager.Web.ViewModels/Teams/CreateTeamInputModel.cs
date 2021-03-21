namespace VacationManager.Web.ViewModels.Teams
{
    using System.ComponentModel.DataAnnotations;
    using VacationManager.Data.Models;

    public class CreateTeamInputModel
    {
        [Required]
        public string Name { get; set; }

        public string LeaderId { get; set; }

        // TODO Select Project option
    }
}
