using Microsoft.EntityFrameworkCore;
using TranTuanThinh_2031200036_Lab.DataContext;
using TranTuanThinh_2031200036_Lab.Models;

namespace TranTuanThinh_2031200036_Lab
{
    public class DatabaseSeeder(AppDataContext dataContext)
    {
        private readonly AppDataContext _dataContext = dataContext;
        private readonly Random _random = new Random();

        public void SeedDataContext()
        {
            try
            {
                _dataContext.Database.EnsureCreated();
                _dataContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Authors ON");
                _dataContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Categories ON");
                _dataContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Users ON");
                _dataContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Books ON");

                var users = new List<User>
                {
                    new User
                    {
                        Fullname = "Alice Johnson",
                        Description = "Library staff",
                        Password = "hashed_password_1",
                        Email = "alice.johnson@example.com",
                        Phone = "1234567890",
                        Address = "123 Main St",
                        Status = "Active",
                        CreatedDate = DateTime.Now,
                        UserCode = "U001",
                        IsLocked = false,
                        IsDeleted = false,
                        IsActive = true,
                        ActiveCode = "ACT123",
                        Avatar = null,
                    },
                    new User
                    {
                        Fullname = "Bob Smith",
                        Description = "Regular member",
                        Password = "hashed_password_2",
                        Email = "bob.smith@example.com",
                        Phone = "0987654321",
                        Address = "456 Elm St",
                        Status = "Active",
                        CreatedDate = DateTime.Now,
                        UserCode = "U002",
                        IsLocked = false,
                        IsDeleted = false,
                        IsActive = true,
                        ActiveCode = "ACT456",
                        Avatar = null,
                    },
                    new User
                    {
                        Fullname = "Charlie Brown",
                        Description = "Premium member",
                        Password = "hashed_password_3",
                        Email = "charlie.brown@example.com",
                        Phone = "5551234567",
                        Address = "789 Oak St",
                        Status = "Inactive",
                        CreatedDate = DateTime.Now,
                        UserCode = "U003",
                        IsLocked = true,
                        IsDeleted = false,
                        IsActive = false,
                        ActiveCode = "ACT789",
                        Avatar = null,
                    },
                };
                _dataContext.Users.AddRange(users);
                _dataContext.SaveChanges();

                var categoryList = new List<Category>
                {
                    new Category
                    {
                        Name = "Programming Book",
                        Description = "Books related to programming.",
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                        IsActive = true,
                    },
                    new Category
                    {
                        Name = "Fiction Book",
                        Description = "Books of fiction genre.",
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                        IsActive = true,
                    },
                    new Category
                    {
                        Name = "Science Fiction Book",
                        Description = "Books about science fiction.",
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                        IsActive = true,
                    },
                };
                _dataContext.Categories.AddRange(categoryList);
                _dataContext.SaveChanges();

                var authors = new List<Author>
                {
                    new Author
                    {
                        FirstName = "Robert",
                        LastName = "Martin",
                        DateOfBirth = new DateTime(1952, 12, 5),
                        Biography = "Author of Clean Code and other programming books.",
                        Nationality = "American",
                        Email = "robert.martin@example.com",
                        Website = "https://cleancoder.com",
                        CreatedDate = DateTime.Now,
                        IsActive = true,
                        Avatar = null,
                    },
                    new Author
                    {
                        FirstName = "J.K.",
                        LastName = "Rowling",
                        DateOfBirth = new DateTime(1965, 7, 31),
                        Biography = "Author of the Harry Potter series.",
                        Nationality = "British",
                        Email = "jk.rowling@example.com",
                        Website = "https://www.jkrowling.com",
                        CreatedDate = DateTime.Now,
                        IsActive = true,
                        Avatar = null,
                    },
                    new Author
                    {
                        FirstName = "Frank",
                        LastName = "Herbert",
                        DateOfBirth = new DateTime(1920, 10, 8),
                        Biography = "Author of the Dune series.",
                        Nationality = "American",
                        Email = "frank.herbert@example.com",
                        Website = null,
                        CreatedDate = DateTime.Now,
                        IsActive = true,
                        Avatar = null,
                    },
                };
                _dataContext.Authors.AddRange(authors);
                _dataContext.SaveChanges();

                var books = new List<Book>
                {
                    new Book
                    {
                        Title = "Clean Code",
                        BookCode = "PB001",
                        Publisher = "Prentice Hall",
                        PublishedYear = 2008,
                        CategoryId = categoryList[0].Id,
                        AuthorId = authors[0].Id,
                        TotalCopies = 10,
                        AvailableCopies = 8,
                        CreatedDate = DateTime.Now,
                        Avatar = null,
                    },
                    new Book
                    {
                        Title = "The Clean Coder",
                        BookCode = "PB002",
                        Publisher = "Prentice Hall",
                        PublishedYear = 2011,
                        CategoryId = categoryList[0].Id,
                        AuthorId = authors[0].Id,
                        TotalCopies = 7,
                        AvailableCopies = 6,
                        CreatedDate = DateTime.Now,
                        Avatar = null,
                    },
                    new Book
                    {
                        Title = "Harry Potter and the Sorcerer's Stone",
                        BookCode = "FB001",
                        Publisher = "Bloomsbury",
                        PublishedYear = 1997,
                        CategoryId = categoryList[1].Id,
                        AuthorId = authors[1].Id,
                        TotalCopies = 15,
                        AvailableCopies = 13,
                        CreatedDate = DateTime.Now,
                        Avatar = null,
                    },
                    new Book
                    {
                        Title = "Harry Potter and the Chamber of Secrets",
                        BookCode = "FB002",
                        Publisher = "Bloomsbury",
                        PublishedYear = 1998,
                        CategoryId = categoryList[1].Id,
                        AuthorId = authors[1].Id,
                        TotalCopies = 14,
                        AvailableCopies = 11,
                        CreatedDate = DateTime.Now,
                        Avatar = null,
                    },
                    new Book
                    {
                        Title = "Dune",
                        BookCode = "SFB001",
                        Publisher = "Chilton Books",
                        PublishedYear = 1965,
                        CategoryId = categoryList[2].Id,
                        AuthorId = authors[2].Id,
                        TotalCopies = 11,
                        AvailableCopies = 9,
                        CreatedDate = DateTime.Now,
                        Avatar = null,
                    },
                    new Book
                    {
                        Title = "Dune Messiah",
                        BookCode = "SFB002",
                        Publisher = "Putnam",
                        PublishedYear = 1969,
                        CategoryId = categoryList[2].Id,
                        AuthorId = authors[2].Id,
                        TotalCopies = 10,
                        AvailableCopies = 8,
                        CreatedDate = DateTime.Now,
                        Avatar = null,
                    },
                };
                _dataContext.Books.AddRange(books);
                _dataContext.SaveChanges();

                _dataContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Authors OFF");
                _dataContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Categories OFF");
                _dataContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Users OFF");
                _dataContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Books OFF");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
            }
        }
    }
}
