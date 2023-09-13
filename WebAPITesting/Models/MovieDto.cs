namespace WebAPITesting.Models
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime Year { get; set; }
        public TimeSpan Lenght { get; set; }
        public string Rating { get; set; } = string.Empty;
    }
}
