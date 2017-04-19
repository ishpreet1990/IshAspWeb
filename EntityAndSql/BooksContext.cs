using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using static System.Console;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SqlServer;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EntityAndSql
{
    public class BooksContext : DbContext
    {
        public BooksContext(DbContextOptions options) : base(options)
{
        }

        public BooksContext()
        {
        }

        public DbSet<Book> Books { get; set; }
    }
   
    public class BooksService
    {

        public readonly BooksContext _booksContext;
        public BooksService(BooksContext context)
        {
            _booksContext = context;
        }
        /*   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
           {
               base.OnConfiguring(optionsBuilder);
               optionsBuilder.UseSqlServer(ConnectionString);
           }*/
        public void AddBook(string title, string publisher)
        {
            Console.WriteLine("5");
            using (var context = new BooksContext())
            {
                var book = new Book
                {
                    Title = title,
                    Publisher = publisher
                };
                context.Add(book);
                int records = context.SaveChanges();
                WriteLine($"{records} records added");
            }
            WriteLine();
        }
        public async Task AddBookAsync()
        {
            var book1 = new Book
            {
                Title = "Proffesional c#5",
                Publisher = "Wrox press 2"
            };
            var book2 = new Book
            {
                Title = "JavaScript for kids",
                Publisher = "Wrox press"
            };
            var book3 = new Book
            {
                Title = "Web design for Html",
                Publisher = "For Dummies"
            };
            _booksContext.AddRange(book1, book2, book3);
            int records = await _booksContext.SaveChangesAsync();

            WriteLine($"{records} records added");
        }
        public void ReadBooks()
        {
            var books = _booksContext.Books;

            //or

            var wroxbooks = from b in _booksContext.Books
                            where b.Publisher == "Wrox"
                            select b;
            foreach (var b in wroxbooks)
            {
                WriteLine($"{b.Title} {b.Publisher}"); //to search a book by publisher name
            }
            WriteLine();
        }
        public async Task UpdateBookAsync()
        {
            int records = 0;
            var book = _booksContext.Books.Where(b => b.Title == "Proffesional c#5")
                .FirstOrDefault();
            if (book != null)
            {
                book.Title = "Proffesional c# and .NET core 6";
                records = await _booksContext.SaveChangesAsync();
            }
            WriteLine($"{records} records updated");
            WriteLine();
        }
        public async Task DeleteBookAsync()
        {
            var books = _booksContext.Books;
                //  var books = context.Books.Where(b => b.Publisher == "For Dummies").FirstOrDefault();
                /*  if(books != null)
                  {
                      context.Books.Remove(books);                                                                //for deleting particular item.
                      records = await context.SaveChangesAsync();
                  }*/
                _booksContext.Books.RemoveRange(books);
                int records = await _booksContext.SaveChangesAsync();
                WriteLine($"{records} records deleted");

            WriteLine();
        }
    }

}
