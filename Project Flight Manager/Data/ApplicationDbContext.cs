using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Project_Flight_Manager.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Models.FlightDataModel> Flights { get; set; }
        public DbSet<Models.UserDataModel> Potrebitel { get; set; }
        public DbSet<Models.ReservationDataModel> Reservations { get; set; }
    }
}
