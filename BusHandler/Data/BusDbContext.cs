using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BusHandler.Data
{
    public class BusDbContext : IdentityDbContext<FamilyUser>
    {
        public BusDbContext(DbContextOptions<BusDbContext> options) : base(options) { }

        public DbSet<Children> Childrens { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
    }
}
