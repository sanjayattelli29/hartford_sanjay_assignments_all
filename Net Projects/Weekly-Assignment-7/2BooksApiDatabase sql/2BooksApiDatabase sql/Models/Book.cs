using System.Text.Json.Serialization;

namespace BookAPIDB.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }

        // Foreign Key
        public int CategoryId { get; set; }
        //It tells which category book belongs to
        // Navigation property
        [JsonIgnore]
        public Category? Category { get; set; }

        public static List<Book> Books = new List<Book>();
    }
}
