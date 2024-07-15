using Calendar.Models;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using Calendar.Utils;

namespace Calendar.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Event>().HasData(
                new Event { Id = 1, Title = "Lunch", Date = DateTime.Now.AddHours(5), Color = Utils.Utils.ColorToHexUInt(Color.Blue)},
                new Event { Id = 2, Title = "Work", Date = DateTime.Now.AddHours(1), Color = Utils.Utils.ColorToHexUInt(Color.Red) },
                new Event { Id = 3, Title = "Start", Date = DateTime.Now.AddHours(-3), Color = Utils.Utils.ColorToHexUInt(Color.Green)});             
        }
    }
}
