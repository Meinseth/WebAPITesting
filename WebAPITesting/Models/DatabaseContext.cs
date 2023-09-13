using Microsoft.EntityFrameworkCore;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebAPITesting.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        //dotnet ef migrations add
        //dotnet ef database update

        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=SQLTesting;Trusted_Connection=true;");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Movie>().HasOne(movie => movie.User).WithMany(user => user.Movies).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
