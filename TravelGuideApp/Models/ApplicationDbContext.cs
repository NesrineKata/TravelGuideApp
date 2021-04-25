using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace TravelGuideApp.Models
{
    public class ApplicationDbContext :DbContext
    {
        // public ApplicationDbContext(DbContextOptions<DbContext> options) : base(options)
        //{}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>().ToTable("Hotel");
            modelBuilder.Entity<Room>().ToTable("Room");
        }

        // The following configures EF to create a Sqlite database file as `C:\blogging.db`.
        // For Mac or Linux, change this to `/tmp/blogging.db` or any other absolute path.
         protected override void OnConfiguring(DbContextOptionsBuilder options) 
            => options.UseSqlite(@"Data Source=travelguide.db");


        public DbSet<Hotel> Hotel { get; set; } 
    public DbSet<Room> Room { get; set; }
       
        
    }
}
