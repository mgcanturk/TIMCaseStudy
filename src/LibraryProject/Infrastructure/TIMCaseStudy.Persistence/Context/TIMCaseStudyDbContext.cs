using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIMCaseStudy.Domain.Entities;
using TIMCaseStudy.Domain.Entities.Common;

namespace TIMCaseStudy.Persistence.Context
{
    public class TIMCaseStudyDbContext : DbContext
    {
        public TIMCaseStudyDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookTransaction> BookTransactions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
  

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Category)
                .WithMany(c => c.Books)
                .HasForeignKey(b => b.CategoryId);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Books)
                .WithOne(b => b.Category)
                .HasForeignKey(b => b.CategoryId);

            modelBuilder.Entity<BookTransaction>()
                .HasOne(bt => bt.Book)
                .WithMany(b => b.BookTransactions)
                .HasForeignKey(bt => bt.BookId);

            modelBuilder.Entity<BookTransaction>()
                .HasOne(bt => bt.Member)
                .WithMany(m => m.BookTransactions)
                .HasForeignKey(bt => bt.MemberId);




            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, NameSurname = "Jane Austen", CreateDateTime = DateTime.Now, UpdateDateTime = DateTime.Now },
                new Author { Id = 2, NameSurname = "William Shakespeare", CreateDateTime = DateTime.Now, UpdateDateTime = DateTime.Now },
                new Author { Id = 3, NameSurname = "Charles Dickens", CreateDateTime = DateTime.Now, UpdateDateTime = DateTime.Now },
                new Author { Id = 4, NameSurname = "Mark Twain", CreateDateTime = DateTime.Now, UpdateDateTime = DateTime.Now },
                new Author { Id = 5, NameSurname = "Oscar Wilde", CreateDateTime = DateTime.Now, UpdateDateTime = DateTime.Now }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Roman", CreateDateTime = DateTime.Now, UpdateDateTime = DateTime.Now },
                new Category { Id = 2, Name = "Dram", CreateDateTime = DateTime.Now, UpdateDateTime = DateTime.Now },
                new Category { Id = 3, Name = "Tarih", CreateDateTime = DateTime.Now, UpdateDateTime = DateTime.Now },
                new Category { Id = 4, Name = "Bilim Kurgu", CreateDateTime = DateTime.Now, UpdateDateTime = DateTime.Now },
                new Category { Id = 5, Name = "Çocuk Kitabı", CreateDateTime = DateTime.Now, UpdateDateTime = DateTime.Now }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Name = "Gurur ve Önyargı",
                    ISBN = "1234567890",
                    Publisher = "Penguin Klasikleri",
                    IsAvailable = true,
                    CategoryId = 1,
                    CreateDateTime = DateTime.Now,
                    UpdateDateTime = DateTime.Now
                },
                new Book
                {
                    Id = 2,
                    Name = "Hamlet",
                    ISBN = "2345678901",
                    Publisher = "Folger Shakespeare Library",
                    IsAvailable = true,
                    CategoryId = 2,
                    CreateDateTime = DateTime.Now,
                    UpdateDateTime = DateTime.Now
                },
                new Book
                {
                    Id = 3,
                    Name = "Tale of Two Cities",
                    ISBN = "3456789012",
                    Publisher = "Penguin Classics",
                    IsAvailable = true,
                    CategoryId = 1,
                    CreateDateTime = DateTime.Now,
                    UpdateDateTime = DateTime.Now
                },
                new Book
                {
                    Id = 4,
                    Name = "The Adventures of Tom Sawyer",
                    ISBN = "4567890123",
                    Publisher = "Penguin Classics",
                    IsAvailable = true,
                    CategoryId = 1,
                    CreateDateTime = DateTime.Now,
                    UpdateDateTime = DateTime.Now
                },
                new Book
                {
                    Id = 5,
                    Name = "The Picture of Dorian Gray",
                    ISBN = "5678901234",
                    Publisher = "Penguin Classics",
                    IsAvailable = true,
                    CategoryId = 1,
                    CreateDateTime = DateTime.Now,
                    UpdateDateTime = DateTime.Now
                }
            );

            modelBuilder.Entity<Member>().HasData(
                new Member { Id = 1, Name = "John Smith", Address = "123 Main St", Phone = "123-456-7890", CreateDateTime = DateTime.Now, UpdateDateTime = DateTime.Now },
                new Member { Id = 2, Name = "Jane Doe", Address = "456 Park Ave", Phone = "456-789-0123", CreateDateTime = DateTime.Now, UpdateDateTime = DateTime.Now },
                new Member { Id = 3, Name = "Ahmet Yılmaz", Address = "789 Main St", Phone = "789-123-4567", CreateDateTime = DateTime.Now, UpdateDateTime = DateTime.Now },
                new Member { Id = 4, Name = "Fatma Öztürk", Address = "246 Park Ave", Phone = "246-789-0123", CreateDateTime = DateTime.Now, UpdateDateTime = DateTime.Now },
                new Member { Id = 5, Name = "Mehmet Kaya", Address = "369 Main St", Phone = "369-123-4567", CreateDateTime = DateTime.Now, UpdateDateTime = DateTime.Now }
            );

            modelBuilder.Entity<BookTransaction>().HasData(
               new BookTransaction
               {
                   Id = 1,
                   BookId = 1,
                   MemberId = 1,
                   RetrieveDate = DateTime.Now.AddDays(-50),
                   ReturnDate = DateTime.Now.AddDays(2),
                   IsLate = false,
                   IsReturn = false,
                   LateDay = 0,
                   Penalty = 0,
                   CreateDateTime = DateTime.Now,
                   UpdateDateTime = DateTime.Now
               },
               new BookTransaction
               {
                   Id = 2,
                   BookId = 2,
                   MemberId = 2,
                   RetrieveDate = DateTime.Now.AddDays(-60),
                   ReturnDate = DateTime.Now.AddDays(-10),
                   IsLate = false,
                   IsReturn = false,
                   LateDay = 0,
                   Penalty = 0,
                   CreateDateTime = DateTime.Now,
                   UpdateDateTime = DateTime.Now
               },
               new BookTransaction
               {
                   Id = 3,
                   BookId = 3,
                   MemberId = 3,
                   RetrieveDate = DateTime.Now,
                   ReturnDate = DateTime.Now.AddDays(1),
                   IsLate = false,
                   IsReturn = false,
                   LateDay = 0,
                   Penalty = 0,
                   CreateDateTime = DateTime.Now,
                   UpdateDateTime = DateTime.Now
               },
               new BookTransaction
               {
                   Id = 4,
                   BookId = 4,
                   MemberId = 4,
                   RetrieveDate = DateTime.Now,
                   ReturnDate = DateTime.Now.AddDays(-5),
                   IsLate = false,
                   IsReturn = false,
                   LateDay = 0,
                   Penalty = 0,
                   CreateDateTime = DateTime.Now,
                   UpdateDateTime = DateTime.Now
               }
            );






















            //modelBuilder.Entity<BookTransaction>()
            //    .HasOne(t => t.Book)
            //    .WithMany(b => b.BookTransactions)
            //    .HasForeignKey(t => t.BookId);

            //modelBuilder.Entity<BookTransaction>()
            //    .HasOne(t => t.Member)
            //    .WithMany(m => m.BookTransactions)
            //    .HasForeignKey(t => t.MemberId);



            //modelBuilder.Entity<Category>()
            //    .HasData(
            //        new Category
            //        {
            //            Id = 1,
            //            Name = "Roman",
            //            CreateDateTime = DateTime.Now,
            //            UpdateDateTime = DateTime.Now
            //        },
            //        new Category
            //        {
            //            Id = 2,
            //            Name = "Hikaye",
            //            CreateDateTime = DateTime.Now,
            //            UpdateDateTime = DateTime.Now
            //        },
            //        new Category
            //        {
            //            Id = 3,
            //            Name = "Tarih",
            //            CreateDateTime = DateTime.Now,
            //            UpdateDateTime = DateTime.Now
            //        },
            //        new Category
            //        {
            //            Id = 4,
            //            Name = "Bilim Kurgu",
            //            CreateDateTime = DateTime.Now,
            //            UpdateDateTime = DateTime.Now
            //        },
            //        new Category
            //        {
            //            Id = 5,
            //            Name = "Korku",
            //            CreateDateTime = DateTime.Now,
            //            UpdateDateTime = DateTime.Now
            //        },
            //        new Category
            //        {
            //            Id = 6,
            //            Name = "Polisiye",
            //            CreateDateTime = DateTime.Now,
            //            UpdateDateTime = DateTime.Now
            //        },
            //        new Category
            //        {
            //            Id = 7,
            //            Name = "Psikoloji",
            //            CreateDateTime = DateTime.Now,
            //            UpdateDateTime = DateTime.Now
            //        },
            //        new Category
            //        {
            //            Id = 8,
            //            Name = "Fantastik",
            //            CreateDateTime = DateTime.Now,
            //            UpdateDateTime = DateTime.Now
            //        },
            //        new Category
            //        {
            //            Id = 9,
            //            Name = "Kişisel Gelişim",
            //            CreateDateTime = DateTime.Now,
            //            UpdateDateTime = DateTime.Now
            //        },
            //        new Category
            //        {
            //            Id = 10,
            //            Name = "Edebiyat",
            //            CreateDateTime = DateTime.Now,
            //            UpdateDateTime = DateTime.Now
            //        }
            //    );
            //modelBuilder.Entity<Member>()
            //    .HasData(
            //        new Member
            //        {
            //            Id = 1,
            //            Name = "Ali Kırkpınar",
            //            Phone = "02122220099",
            //            Address = "İstanbul",
            //            CreateDateTime = DateTime.Now,
            //            UpdateDateTime = DateTime.Now
            //        },
            //        new Member
            //        {
            //            Id = 2,
            //            Name = "Veli Karapınar",
            //            Phone = "02125670798",
            //            Address = "İstanbul",
            //            CreateDateTime = DateTime.Now,
            //            UpdateDateTime = DateTime.Now
            //        },
            //        new Member
            //        {
            //            Id = 3,
            //            Name = "Kahraman Paladin",
            //            Phone = "02122135691",
            //            Address = "Ankara",
            //            CreateDateTime = DateTime.Now,
            //            UpdateDateTime = DateTime.Now
            //        }
            //    );
            //modelBuilder.Entity<Author>()
            //    .HasData(
            //        new Author
            //        {
            //            Id = 1,
            //            NameSurname = "Sabahattin Ali",
            //            CreateDateTime = DateTime.Now,
            //            UpdateDateTime = DateTime.Now
            //        },
            //        new Author
            //        {
            //            Id = 2,
            //            NameSurname = "Stefan Zweig",
            //            CreateDateTime = DateTime.Now,
            //            UpdateDateTime = DateTime.Now
            //        },
            //        new Author
            //        {
            //            Id = 3,
            //            NameSurname = "Yaşar Kemal",
            //            CreateDateTime = DateTime.Now,
            //            UpdateDateTime = DateTime.Now
            //        },
            //        new Author
            //        {
            //            Id = 4,
            //            NameSurname = "Doğan Cüceloğlu",
            //            CreateDateTime = DateTime.Now,
            //            UpdateDateTime = DateTime.Now
            //        },
            //        new Author
            //        {
            //            Id = 5,
            //            NameSurname = "Şermin Yaşar",
            //            CreateDateTime = DateTime.Now,
            //            UpdateDateTime = DateTime.Now
            //        }
            //    );
            //modelBuilder.Entity<Book>()
            //    .HasData(
            //        new Book
            //        {
            //            Id = 1,
            //            Name = "Pamuk Prenses ve Yedi Cüceler",
            //            ISBN = "1234567890",
            //            Publisher = "Doğan Kitap",
            //            IsAvailable = true,
            //            CategoryId = 1,
            //            AuthorId = 1,
            //            CreateDateTime = DateTime.Now,
            //            UpdateDateTime = DateTime.Now
            //        },
            //        new Book
            //        {
            //            Id = 2,
            //            Name = "Alacakaranlık",
            //            ISBN = "1234567891",
            //            Publisher = "Doğan Kitap",
            //            IsAvailable = true,
            //            CategoryId = 1,
            //            AuthorId = 2,
            //            CreateDateTime = DateTime.Now,
            //            UpdateDateTime = DateTime.Now
            //        },
            //        new Book
            //        {
            //            Id = 3,
            //            Name = "Harry Potter ve Felsefe Taşı",
            //            ISBN = "1234567892",
            //            Publisher = "Pegasus Yayınları",
            //            IsAvailable = true,
            //            CategoryId = 1,
            //            AuthorId = 3,
            //            CreateDateTime = DateTime.Now,
            //            UpdateDateTime = DateTime.Now
            //        },
            //        new Book
            //        {
            //            Id = 4,
            //            Name = "Yüzüklerin Efendisi: Kralın Dönüşü",
            //            ISBN = "1234567893",
            //            Publisher = "Pegasus Yayınları",
            //            IsAvailable = true,
            //            CategoryId = 2,
            //            AuthorId = 2,
            //            CreateDateTime = DateTime.Now,
            //            UpdateDateTime = DateTime.Now
            //        },
            //        new Book
            //        {
            //            Id = 5,
            //            Name = "Sıradışı Öğrenciler",
            //            ISBN = "1234567894",
            //            Publisher = "Doğan Kitap",
            //            IsAvailable = true,
            //            CategoryId = 3,
            //            AuthorId = 1,
            //            CreateDateTime = DateTime.Now,
            //            UpdateDateTime = DateTime.Now
            //        },
            //        new Book
            //        {
            //            Id = 6,
            //            Name = "Ormanlar Kralı",
            //            ISBN = "1234567895",
            //            Publisher = "Doğan Kitap",
            //            IsAvailable = true,
            //            CategoryId = 3,
            //            AuthorId = 2,
            //            CreateDateTime = DateTime.Now,
            //            UpdateDateTime = DateTime.Now
            //        },
            //        new Book
            //        {
            //            Id = 7,
            //            Name = "Japon Edebiyatı Tarihi",
            //            ISBN = "1234567897",
            //            Publisher = "Doğan Kitap",
            //            IsAvailable = true,
            //            CategoryId = 3,
            //            AuthorId = 4,
            //            CreateDateTime = DateTime.Now,
            //            UpdateDateTime = DateTime.Now
            //        },
            //        new Book
            //        {
            //            Id = 8,
            //            Name = "Tarihte İslam Dünyası",
            //            ISBN = "1234567898",
            //            Publisher = "Pegasus Yayınları",
            //            IsAvailable = true,
            //            CategoryId = 3,
            //            AuthorId = 4,
            //            CreateDateTime = DateTime.Now,
            //            UpdateDateTime = DateTime.Now
            //        },
            //        new Book
            //        {
            //            Id = 9,
            //            Name = "Yunan Mitolojisi",
            //            ISBN = "1234567899",
            //            Publisher = "Doğan Kitap",
            //            IsAvailable = true,
            //            CategoryId = 2,
            //            AuthorId = 2,
            //            CreateDateTime = DateTime.Now,
            //            UpdateDateTime = DateTime.Now
            //        },
            //        new Book
            //        {
            //            Id = 10,
            //            Name = "İngiliz Tarihi",
            //            ISBN = "12345678910",
            //            Publisher = "Pegasus Yayınları",
            //            IsAvailable = true,
            //            CategoryId = 4,
            //            AuthorId = 1,
            //            CreateDateTime = DateTime.Now,
            //            UpdateDateTime = DateTime.Now
            //        }
            //    );
            //modelBuilder.Entity<BookTransaction>()
            //   .HasData(
            //       new BookTransaction
            //       {
            //           Id = 1,
            //           Book = new Book
            //           {
            //               Id = 7,
            //               Name = "Japon Edebiyatı Tarihi",
            //               ISBN = "1234567897",
            //               Publisher = "Doğan Kitap",
            //               IsAvailable = true,
            //               CategoryId = 3,
            //               AuthorId = 4,
            //               CreateDateTime = DateTime.Now,
            //               UpdateDateTime = DateTime.Now
            //           },
            //           Member = new Member
            //           {
            //               Id = 1,
            //               NameSurname = "Ali Kırkpınar",
            //               Age = 25,
            //               City = "İstanbul",
            //               CreateDateTime = DateTime.Now,
            //               UpdateDateTime = DateTime.Now
            //           },
            //           RetrieveDate = DateTime.Now.AddDays(-10),
            //           ReturnDate = DateTime.Now,
            //           IsLate = false,
            //           LateDay = 0,
            //           Penalty = 0.0m
            //       },
            //       new BookTransaction
            //       {
            //           Id = 2,
            //           Book = new Book
            //           {
            //               Id = 9,
            //               Name = "Yunan Mitolojisi",
            //               ISBN = "1234567899",
            //               Publisher = "Doğan Kitap",
            //               IsAvailable = true,
            //               CategoryId = 2,
            //               AuthorId = 2,
            //               CreateDateTime = DateTime.Now,
            //               UpdateDateTime = DateTime.Now
            //           },
            //           Member = new Member
            //           {
            //               Id = 2,
            //               NameSurname = "Veli Karapınar",
            //               Age = 32,
            //               City = "İstanbul",
            //               CreateDateTime = DateTime.Now,
            //               UpdateDateTime = DateTime.Now
            //           },
            //           RetrieveDate = DateTime.Now.AddDays(-31),
            //           ReturnDate = DateTime.Now,
            //           IsLate = true,
            //           LateDay = 1,
            //           Penalty = 0.20m
            //       },
            //       new BookTransaction
            //       {
            //           Id = 3,
            //           Book = new Book
            //           {
            //               Id = 10,
            //               Name = "İngiliz Tarihi",
            //               ISBN = "12345678910",
            //               Publisher = "Pegasus Yayınları",
            //               IsAvailable = true,
            //               CategoryId = 4,
            //               AuthorId = 1,
            //               CreateDateTime = DateTime.Now,
            //               UpdateDateTime = DateTime.Now
            //           },
            //           Member = new Member
            //           {
            //               Id = 2,
            //               NameSurname = "Veli Karapınar",
            //               Age = 32,
            //               City = "İstanbul",
            //               CreateDateTime = DateTime.Now,
            //               UpdateDateTime = DateTime.Now
            //           },
            //           RetrieveDate = DateTime.Now.AddDays(-35),
            //           ReturnDate = DateTime.Now,
            //           IsLate = true,
            //           LateDay = 5,
            //           Penalty = 3.80m
            //       }
            //    );
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker
                 .Entries<BaseEntity>();

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreateDateTime = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdateDateTime = DateTime.UtcNow,
                    _ => DateTime.UtcNow
                };
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
