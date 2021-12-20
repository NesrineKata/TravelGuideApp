using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace TravelGuideApp.Models
{
    public class ApplicationDbContext : DbContext
    {
        // public ApplicationDbContext(DbContextOptions<DbContext> options) : base(options)
        //{}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>().ToTable("Address");
            modelBuilder.Entity<Hotel>().ToTable("Hotel");
            modelBuilder.Entity<Room>().ToTable("Room");
            modelBuilder.Entity<Activity>().ToTable("Activity");
            modelBuilder.Entity<Bus>().ToTable("Bus");
            modelBuilder.Entity<Restaurant>().ToTable("Restaurant");
            modelBuilder.Entity<TouristicSite>().ToTable("TouristicSite");
            modelBuilder.Entity<Transport>().ToTable("Transport");
            modelBuilder.Entity<Review>().ToTable("Review");

        }

        // The following configures EF to create a Sqlite database file as `C:\blogging.db`.
        // For Mac or Linux, change this to `/tmp/blogging.db` or any other absolute path.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
           => options.UseSqlite(@"Data Source=travelguide.db");


        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<Review> Review { get; set; }
        public DbSet<Activity> Activity { get; set; }
        public DbSet<Bus> Bus { get; set; }
        public DbSet<Transport> Transport { get; set; }
        public DbSet<TouristicSite> TouristicSite { get; set; }
        public DbSet<Restaurant> Restaurant { get; set; }




    }
}

