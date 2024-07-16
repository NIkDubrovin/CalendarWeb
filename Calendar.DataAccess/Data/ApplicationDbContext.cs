using Calendar.Models;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using Calendar.Utils;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Calendar.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
           // this.Obj
           // ((IObjectContextAdapter)this).ObjectContext.ObjectMaterialized +=
           //(sender, e) => DateTimeKindAttribute.Apply(e.Entity);
        }

        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

          
            modelBuilder.Entity<Event>().HasData(
                new Event { Id = 1, Title = "Lunch", Date = DateTime.Now.AddHours(5).ToString(), Color = "FF0000" },
                new Event { Id = 2, Title = "Work", Date = DateTime.Now.AddHours(1).ToString(), Color = "FFFF00" },
                new Event { Id = 3, Title = "Start", Date = DateTime.Now.AddHours(-3).ToString(), Color = "00FFFF" });             
        }
    }
}
