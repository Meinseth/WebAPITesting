namespace WebAPITesting.Models
{
    public class AppUserDto
    {
        public required string Id { get; set; }
        public required string Firstname { get; set; }
        public required string Lastname { get; set; }
        public required string Email { get; set; }
        public string Fullname => Firstname + " " + Lastname;
    }
}
