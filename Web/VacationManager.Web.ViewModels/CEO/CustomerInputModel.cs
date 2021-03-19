namespace VacationManager.Web.ViewModels.CEO
{
    using System.ComponentModel.DataAnnotations;

    using VacationManager.Data.Models.Enums;

    public class CustomerInputModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public Role Role { get; set; }

    }
}
