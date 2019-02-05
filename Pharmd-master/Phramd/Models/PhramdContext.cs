using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phramd.Models
{
    public class PhramdContext : DbContext
    {
        public PhramdContext(DbContextOptions<PhramdContext> options) : base(options)
        { }

        public DbSet<User> User { get; set; }
        public DbSet<CalendarModel> CalendarModel { get; set; }
        public DbSet<PhotoAccounts> PhotoAccounts { get; set; }
        public DbSet<WeatherDB> Weather { get; set; }
        public DbSet<NewsDB> News { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<CalendarModel>().ToTable("CalendarModel");
            modelBuilder.Entity<PhotoAccounts>().ToTable("PhotoAccounts");
            modelBuilder.Entity<NewsDB>().ToTable("News");
            modelBuilder.Entity<WeatherDB>().ToTable("Weather");
        }
    }
}