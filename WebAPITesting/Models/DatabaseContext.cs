using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace WebAPITesting.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>().HasData(
                new User { Id = 1,Username = "mindseth", Password = "12113662", Firstname = "vebjorn", Lastname = "meinseth", Email = "vebjor@meinseth.no" }
            );

        }
    }
}
