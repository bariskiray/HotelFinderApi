using HotelFinder.Entites;
using Microsoft.EntityFrameworkCore;

namespace HotelFinder.DataAccess
{
    public class HotelDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=IES01; Database=HotelDb; Trusted_Connection=true;");
        }
        public DbSet<Hotel> Hotels { get; set; }
    }
}