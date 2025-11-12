namespace BookAppAPI.CommandQueries
{
    public class BookCommand
    {
        public long Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public int? Year { get; set; }
    }

    public class BookQuery
    {
        public long Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public int? Year { get; set; }
    }
}
