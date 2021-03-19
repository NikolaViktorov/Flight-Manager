namespace VacationManager.Data.Models.Models
{
    using System;

    public class Vacation
    {
        public Vacation()
        {
            this.VacationId = Guid.NewGuid().ToString();
        }

        public string VacationId { get; set; }

        public DateTime? Start { get; set; }

        public DateTime? End { get; set; }

        public DateTime? CreatedOn { get; set; }

        public bool IsHalfDay { get; set; }

        public bool IsAccepted { get; set; }

        public ApplicationUser Employee { get; set; }

        public string EmployeeId { get; set; }
    }
}
