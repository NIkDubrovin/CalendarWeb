using Calendar.Models;
using Microsoft.EntityFrameworkCore;

namespace Calendar.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", Color = "" },
                new Category { Id = 2, Name = "SciFi", Color = "" },
                 new Category { Id = 3, Name = "History", Color = "" }
            );

            modelBuilder.Entity<Event>().HasData(
                new Event { Id = 1, Title = "Test Event", StartDate = DateTime.Now });
        }
    }
}
