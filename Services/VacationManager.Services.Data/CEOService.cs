namespace VacationManager.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using VacationManager.Data;
    using VacationManager.Services.Data.Contracts;
    using VacationManager.Web.ViewModels.CEO;

    public class CEOService : ICEOService
    {
        private readonly ApplicationDbContext db;

        public CEOService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task DeleteCustomerAccount(string customerId)
        {
            var customer = await this.db.Users.FirstOrDefaultAsync(u => u.Id == customerId);

            if (customer == null)
            {
                throw new ArgumentException("Несъществува такъв клиент!");
            }

            this.db.Users.Remove(customer);
            await this.db.SaveChangesAsync();
        }

        public async Task<ICollection<CustomerViewModel>> GetAll()
        {
            // Change to given amount
            return await this.db.Users.Select(u => new CustomerViewModel()
            {
                CustomerId = u.Id,
                Email = u.Email,
                FirstName = u.FirstName,
                LastName = u.LastName,
            }).ToListAsync();
        }

        public async Task<CustomerDetailsViewModel> GetCustomer(string customerId)
        {
            var customer = await this.db.Users.FirstOrDefaultAsync(u => u.Id == customerId);

            if (customer == null)
            {
                throw new ArgumentException("Несъществува такъв клиент!");
            }

            return new CustomerDetailsViewModel()
            {
                CustomerId = customer.Id,
                Email = customer.Email,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Role = customer.Role,
                Username = customer.UserName,
                HasTeam = customer.Team != null,
            };
        }
    }
}
