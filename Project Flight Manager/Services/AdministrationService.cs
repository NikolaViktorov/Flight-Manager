using Microsoft.EntityFrameworkCore;
using Project_Flight_Manager.Data;
using Project_Flight_Manager.Services.Contracts;
using Project_Flight_Manager.ViewModels.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Flight_Manager.Services
{
    public class AdministrationService : IAdministrationService
    {
        private readonly ApplicationDbContext db;

        public AdministrationService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task DeleteUser(string id)
        {
            var user = await this.db.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                throw new ArgumentException("User with given id does not exits!");
            }

            this.db.Users.Remove(user);
            await this.db.SaveChangesAsync();
        }

        public Task<List<UserViewModel>> GetUsers(int count, string filter, string curId)
        {
            switch (filter)
            {
                case "email":
                    return this.db.Users
                        .Where(u => u.Id != curId)
                        .Take(count)
                        .OrderBy(u => u.Email).Select(u => new UserViewModel()
                        {
                            UserId = u.Id,
                            Username = u.UserName,
                            Email = u.Email,
                        }).ToListAsync();
                case "username":
                    return this.db.Users
                        .Where(u => u.Id != curId)
                         .Take(count)
                        .OrderBy(u => u.UserName).Select(u => new UserViewModel()
                        {
                            Username = u.UserName,
                            UserId = u.Id,
                            Email = u.Email,
                        }).ToListAsync();
                default:
                    return this.db.Users
                        .Where(u => u.Id != curId)
                        .Take(count)
                        .Select(u => new UserViewModel()
                    {
                        UserId = u.Id,
                        Username = u.UserName,
                        Email = u.Email,
                        }).ToListAsync();
            }
        }

        private bool isNotAdmin(string id)
        {
            return this.db.UserRoles.FirstOrDefault(ur => ur.UserId == id) == null;
        }
    }
}
