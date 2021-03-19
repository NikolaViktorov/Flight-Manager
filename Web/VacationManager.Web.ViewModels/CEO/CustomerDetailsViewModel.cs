namespace VacationManager.Web.ViewModels.CEO
{
    using VacationManager.Data.Models.Enums;

    public class CustomerDetailsViewModel
    {
        public string CustomerId { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public Role Role { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool HasTeam { get; set; }
    }
}
