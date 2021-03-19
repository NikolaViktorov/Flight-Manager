// ReSharper disable VirtualMemberCallInConstructor
namespace VacationManager.Data.Models
{
    using System;
    using System.Collections.Generic;

    using VacationManager.Data.Common.Models;

    using Microsoft.AspNetCore.Identity;
    using VacationManager.Data.Models.Models;
    using VacationManager.Data.Models.Enums;
    using System.ComponentModel.DataAnnotations;

    public class ApplicationUser : IdentityUser, IAuditInfo
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
            this.Vacations = new HashSet<Vacation>();
        }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Team Team { get; set; }

        public string TeamId { get; set; }

        [Required]
        public virtual int RoleId { get; set; }

        [EnumDataType(typeof(Role))]
        public Role Role
        {
            get
            {
                return (Role)this.RoleId;
            }

            set
            {
                this.RoleId = (int)value;
            }
        }

        public virtual ICollection<Vacation> Vacations { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
    }
}
