using Hospital.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Data
{
    public class ApplicationDbContext:DbContext
    {

        public DbSet<Doctor> doctors { get; set; }
        public DbSet<Book> books { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var bulider = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();

            var connection = bulider.GetConnectionString("defualtConnection");

            optionsBuilder.UseSqlServer(connection);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Doctor>().HasMany(e=>e.books)
                .WithMany(e=>e.doctors);
        }
    }
}
