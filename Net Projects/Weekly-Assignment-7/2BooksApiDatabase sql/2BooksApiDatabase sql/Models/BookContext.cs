using BookAPIDB.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BookAPIDB.Models
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}