using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace WebAPITesting.Models
{
    public class AppUser : IdentityUser
    {
        public required string Firstname { get; set; }
        public required string Lastname { get; set; }
        public string Fullname => Firstname + " " + Lastname;
        public List<Movie> Movies { get; set; } = new();

    }
}
