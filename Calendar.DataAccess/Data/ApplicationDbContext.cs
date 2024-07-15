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

            modelBuilder.Entity<Event>()
                .Property(e => e.Date)
                .HasConversion(
                    v => v,
                    v => new DateTime(v.Ticks, DateTimeKind.Unspecified));
            //modelBuilder.Entity<Event>().Property(e => e.Date).HasConversion(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Unspecified));
            modelBuilder.Entity<Event>().HasData(
                new Event { Id = 1, Title = "Lunch", Date = DateTime.Now.AddHours(5), Color = "FF0000" },
                new Event { Id = 2, Title = "Work", Date = DateTime.Now.AddHours(1), Color = "FFFF00" },
                new Event { Id = 3, Title = "Start", Date = DateTime.Now.AddHours(-3), Color = "00FFFF" });             
        }
    }
}
