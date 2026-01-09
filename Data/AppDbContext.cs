using Microsoft.EntityFrameworkCore;
using BloodLink.Models;

namespace BloodLink.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // this wwill say "There is a table called Donors, treat it like a list of Donor objects"
        public DbSet<Donor> Donors { get; set; }

        // The BloodRequests Table 
        public DbSet<BloodRequest> BloodRequests { get; set; }
    }
}