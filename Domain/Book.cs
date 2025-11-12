namespace BookAppAPI.Domain
{
    public class Book
    {
        public long Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public int? Year { get; set; }

        public bool IsDeleted { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateAt { get; set; }
        public string? EditBy { get; set; }
        public DateTime? EditAt { get; set; }
        public string? DeleteBy { get; set; }
        public DateTime? DeleteAt { get; set; }
    }
}
