using Microsoft.EntityFrameworkCore;
using TranTuanThinh_2031200036_Lab.Models;

namespace TranTuanThinh_2031200036_Lab.DataContext
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Carousel> Carousels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId);
            });

            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(e => e.AuthorId);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CategoryId);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.BookId);

                entity
                    .HasOne(b => b.Author)
                    .WithMany(a => a.Books)
                    .HasForeignKey(b => b.AuthorId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity
                    .HasOne(b => b.Category)
                    .WithMany(c => c.Books)
                    .HasForeignKey(b => b.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Loan>(entity =>
            {
                entity.HasKey(e => e.LoanId);

                entity
                    .HasOne(l => l.User)
                    .WithMany(u => u.Loans)
                    .HasForeignKey(l => l.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity
                    .HasOne(l => l.Book)
                    .WithMany(b => b.Loans)
                    .HasForeignKey(l => l.BookId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Carousel>(entity =>
            {
                entity.HasKey(c => c.CarouselId);

                entity.Property(c => c.ImageUrl).IsRequired();
                entity.Property(c => c.Title).HasMaxLength(200).IsRequired();
                entity.Property(c => c.Order).IsRequired();
            });
        }
    }
}
