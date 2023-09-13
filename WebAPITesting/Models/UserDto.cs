namespace WebAPITesting.Models
{
    public class UserDto
    {
        public Guid Guid { get; set; } = Guid.NewGuid();
        public required string Firstname { get; set; }
        public required string Lastname { get; set; }
        public required string Email { get; set; }
        public string Fullname => Firstname + " " + Lastname;
    }
}
