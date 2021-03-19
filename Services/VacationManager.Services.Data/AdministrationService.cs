namespace VacationManager.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    using VacationManager.Web.ViewModels.Administration;
    using VacationManager.Data;
    using VacationManager.Services.Data.Contracts;
    using VacationManager.Data.Models.Models;
    using VacationManager.Common;
    using VacationManager.Data.Models;

    public class AdministrationService : IAdministrationService
    {
        private readonly ApplicationDbContext db;

        public AdministrationService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task AddCEO(CEOInputModel input)
        {
            var user = await this.db.Users.FirstOrDefaultAsync(u => u.Email == input.Email
            && u.FirstName == input.FirstName
            && u.LastName == input.LastName);

            if (user == null)
            {
                throw new ArgumentException("Няма регистриран човек с тази информация!");
            }

            var asCEO = user as CEO;
            if (asCEO != null)
            {
                throw new ArgumentException("Този човек вече е CEO.");
            }

            var newRoles = new List<IdentityUserRole<string>>();
            var userRoles = await this.db.UserRoles.Where(ur => ur.UserId == user.Id).ToListAsync();

            newRoles.AddRange(userRoles);

            this.db.UserRoles.RemoveRange(userRoles);
            await this.db.SaveChangesAsync();
            this.db.Users.Remove(user);

            var CEO = new CEO()
            {
                UserName = user.UserName,
                Roles = user.Roles,
                Claims = user.Claims,
                TwoFactorEnabled = user.TwoFactorEnabled,
                PhoneNumber = user.PhoneNumber,
                ConcurrencyStamp = user.ConcurrencyStamp,
                NormalizedEmail = user.NormalizedEmail,
                Email = user.Email,
                NormalizedUserName = user.NormalizedUserName,
                EmailConfirmed = user.EmailConfirmed,
                SecurityStamp = user.SecurityStamp,
                PasswordHash = user.PasswordHash,
                PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                Logins = user.Logins,
                FirstName = input.FirstName,
                LastName = input.LastName,
            };

            var CEORoleId = (await this.db.Roles.FirstOrDefaultAsync(r => r.Name == GlobalConstants.CEORoleName)).Id;

            await this.db.CEOs.AddAsync(CEO);
            await this.db.SaveChangesAsync();

            newRoles.ForEach(r => r.UserId = CEO.Id);
            newRoles.Add(new IdentityUserRole<string>()
            {
                UserId = CEO.Id,
                RoleId = CEORoleId,
            });

            await this.db.UserRoles.AddRangeAsync(newRoles);
            await this.db.SaveChangesAsync();
        }

        public async Task RemoveCEO(CEORemoveModel input)
        {
            var CEO = await this.db.CEOs.FirstOrDefaultAsync(u => u.Email == input.Email);

            if (CEO == null)
            {
                throw new ArgumentException("Няма регистриран човек с този е-мейл.");
            }

            var asCEO = CEO as CEO;
            if (asCEO == null)
            {
                throw new ArgumentException("Този човек не е треньор.");
            }

            var oldRoles = new List<IdentityUserRole<string>>();
            var userRoles = await this.db.UserRoles.Where(ur => ur.UserId == CEO.Id).ToListAsync();

            var CEORoleId = (await this.db.Roles.FirstOrDefaultAsync(r => r.Name == GlobalConstants.CEORoleName)).Id;

            oldRoles.AddRange(userRoles.Where(ur => ur.RoleId != CEORoleId).ToList());

            this.db.UserRoles.RemoveRange(userRoles);
            await this.db.SaveChangesAsync();

            var user = new ApplicationUser()
            {
                UserName = CEO.UserName,
                Roles = CEO.Roles,
                Claims = CEO.Claims,
                TwoFactorEnabled = CEO.TwoFactorEnabled,
                PhoneNumber = CEO.PhoneNumber,
                ConcurrencyStamp = CEO.ConcurrencyStamp,
                NormalizedEmail = CEO.NormalizedEmail,
                Email = CEO.Email,
                NormalizedUserName = CEO.NormalizedUserName,
                EmailConfirmed = CEO.EmailConfirmed,
                SecurityStamp = CEO.SecurityStamp,
                PasswordHash = CEO.PasswordHash,
                PhoneNumberConfirmed = CEO.PhoneNumberConfirmed,
                Logins = CEO.Logins,
                FirstName = CEO.FirstName,
                LastName = CEO.LastName,
            };

            this.db.Users.Remove(CEO);

            await this.db.Users.AddAsync(user);
            await this.db.SaveChangesAsync();

            oldRoles.ForEach(r => r.UserId = user.Id);

            await this.db.UserRoles.AddRangeAsync(oldRoles);
            await this.db.SaveChangesAsync();
        }
    }
}
