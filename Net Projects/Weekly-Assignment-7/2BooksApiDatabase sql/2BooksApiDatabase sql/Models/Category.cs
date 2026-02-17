using BookAPIDB.Models;

namespace BookAPIDB.Models
{
    public class Category
    {
        //ID -> Primary Key
        public int Id { get; set; }

        //Name -> category name
        public string Name { get; set; }

        // One Category → Many Books
        public List<Book>? Books { get; set; } = new List<Book>();

        public static List<Category> Categories = new List<Category>();

        //Category -> Parent , Books -> Children
        //Static list stores data in memory
    }
}