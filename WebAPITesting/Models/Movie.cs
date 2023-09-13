namespace WebAPITesting.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public required User User { get; set; }
        public int Position { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime Year { get; set; }
        public TimeSpan Length { get; set; }
        public string Rating { get; set; } = string.Empty; 
    }
}
