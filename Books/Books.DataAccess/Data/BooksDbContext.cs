using Books.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.DataAccess.Data
{
    public class BooksDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<BookPublisher> BookPublisher { get; set; }

        public BooksDbContext()
        {

        }
        // gets the options(where to work info) from startup
        // create the options according to BooksDbContext 
        // send the option gotten from Startup to DbContext
        public BooksDbContext(DbContextOptions<BooksDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                        .Property(b => b.Title)
                        .IsRequired();
            modelBuilder.Entity<User>()
                        .Property(u => u.Username)
                        .IsRequired();

            modelBuilder.Entity<Book>()
                        .HasOne(b => b.Category)
                        .WithMany(c => c.Books)
                        .HasForeignKey(b => b.CategoryId)
                        .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Book>()
                        .HasOne(b => b.Author)
                        .WithMany(c => c.Books)
                        .HasForeignKey(b => b.AuthorId)
                        .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<BookPublisher>()
                        .HasKey(bp => new { bp.BookId, bp.PublisherId });

            modelBuilder.Entity<BookPublisher>()
                        .HasOne(bp => bp.Book)
                        .WithMany(book => book.Publishers)
                        .HasForeignKey(bp => bp.PublisherId);

            modelBuilder.Entity<BookPublisher>()
                        .HasOne(bp => bp.Publisher)
                        .WithMany(pub => pub.Books)
                        .HasForeignKey(bp => bp.BookId);


            base.OnModelCreating(modelBuilder);
        }
    }
}
