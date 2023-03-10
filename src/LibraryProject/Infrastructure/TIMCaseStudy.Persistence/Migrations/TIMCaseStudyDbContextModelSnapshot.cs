// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TIMCaseStudy.Persistence.Context;

#nullable disable

namespace TIMCaseStudy.Persistence.Migrations
{
    [DbContext(typeof(TIMCaseStudyDbContext))]
    partial class TIMCaseStudyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.Property<int>("AuthorsId")
                        .HasColumnType("int");

                    b.Property<int>("BooksId")
                        .HasColumnType("int");

                    b.HasKey("AuthorsId", "BooksId");

                    b.HasIndex("BooksId");

                    b.ToTable("AuthorBook");
                });

            modelBuilder.Entity("TIMCaseStudy.Domain.Entities.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("NameSurname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateDateTime = new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(6867),
                            NameSurname = "Jane Austen",
                            UpdateDateTime = new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(6878)
                        },
                        new
                        {
                            Id = 2,
                            CreateDateTime = new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(6883),
                            NameSurname = "William Shakespeare",
                            UpdateDateTime = new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(6884)
                        },
                        new
                        {
                            Id = 3,
                            CreateDateTime = new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(6886),
                            NameSurname = "Charles Dickens",
                            UpdateDateTime = new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(6886)
                        },
                        new
                        {
                            Id = 4,
                            CreateDateTime = new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(6888),
                            NameSurname = "Mark Twain",
                            UpdateDateTime = new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(6888)
                        },
                        new
                        {
                            Id = 5,
                            CreateDateTime = new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(6889),
                            NameSurname = "Oscar Wilde",
                            UpdateDateTime = new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(6890)
                        });
                });

            modelBuilder.Entity("TIMCaseStudy.Domain.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            CreateDateTime = new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7099),
                            ISBN = "1234567890",
                            IsAvailable = true,
                            Name = "Gurur ve Önyargı",
                            Publisher = "Penguin Klasikleri",
                            UpdateDateTime = new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7100)
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            CreateDateTime = new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7102),
                            ISBN = "2345678901",
                            IsAvailable = true,
                            Name = "Hamlet",
                            Publisher = "Folger Shakespeare Library",
                            UpdateDateTime = new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7103)
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            CreateDateTime = new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7105),
                            ISBN = "3456789012",
                            IsAvailable = true,
                            Name = "Tale of Two Cities",
                            Publisher = "Penguin Classics",
                            UpdateDateTime = new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7106)
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 1,
                            CreateDateTime = new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7107),
                            ISBN = "4567890123",
                            IsAvailable = true,
                            Name = "The Adventures of Tom Sawyer",
                            Publisher = "Penguin Classics",
                            UpdateDateTime = new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7108)
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 1,
                            CreateDateTime = new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7111),
                            ISBN = "5678901234",
                            IsAvailable = true,
                            Name = "The Picture of Dorian Gray",
                            Publisher = "Penguin Classics",
                            UpdateDateTime = new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7111)
                        });
                });

            modelBuilder.Entity("TIMCaseStudy.Domain.Entities.BookTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsLate")
                        .HasColumnType("bit");

                    b.Property<bool>("IsReturn")
                        .HasColumnType("bit");

                    b.Property<int>("LateDay")
                        .HasColumnType("int");

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<decimal>("Penalty")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("RetrieveDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("MemberId");

                    b.ToTable("BookTransactions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BookId = 1,
                            CreateDateTime = new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7171),
                            IsLate = false,
                            IsReturn = false,
                            LateDay = 0,
                            MemberId = 1,
                            Penalty = 0m,
                            RetrieveDate = new DateTime(2022, 10, 30, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7163),
                            ReturnDate = new DateTime(2022, 12, 21, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7168),
                            UpdateDateTime = new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7171)
                        },
                        new
                        {
                            Id = 2,
                            BookId = 2,
                            CreateDateTime = new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7175),
                            IsLate = false,
                            IsReturn = false,
                            LateDay = 0,
                            MemberId = 2,
                            Penalty = 0m,
                            RetrieveDate = new DateTime(2022, 10, 20, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7172),
                            ReturnDate = new DateTime(2022, 11, 29, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7173),
                            UpdateDateTime = new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7175)
                        },
                        new
                        {
                            Id = 3,
                            BookId = 3,
                            CreateDateTime = new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7178),
                            IsLate = false,
                            IsReturn = false,
                            LateDay = 0,
                            MemberId = 3,
                            Penalty = 0m,
                            RetrieveDate = new DateTime(2022, 11, 14, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7176),
                            ReturnDate = new DateTime(2022, 12, 14, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7177),
                            UpdateDateTime = new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7179)
                        },
                        new
                        {
                            Id = 4,
                            BookId = 4,
                            CreateDateTime = new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7181),
                            IsLate = false,
                            IsReturn = false,
                            LateDay = 0,
                            MemberId = 4,
                            Penalty = 0m,
                            RetrieveDate = new DateTime(2022, 12, 14, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7180),
                            ReturnDate = new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7181),
                            UpdateDateTime = new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7182)
                        });
                });

            modelBuilder.Entity("TIMCaseStudy.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateDateTime = new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7066),
                            Name = "Roman",
                            UpdateDateTime = new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7068)
                        },
                        new
                        {
                            Id = 2,
                            CreateDateTime = new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7070),
                            Name = "Dram",
                            UpdateDateTime = new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7071)
                        },
                        new
                        {
                            Id = 3,
                            CreateDateTime = new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7072),
                            Name = "Tarih",
                            UpdateDateTime = new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7072)
                        },
                        new
                        {
                            Id = 4,
                            CreateDateTime = new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7073),
                            Name = "Bilim Kurgu",
                            UpdateDateTime = new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7074)
                        },
                        new
                        {
                            Id = 5,
                            CreateDateTime = new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7075),
                            Name = "Çocuk Kitabı",
                            UpdateDateTime = new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7075)
                        });
                });

            modelBuilder.Entity("TIMCaseStudy.Domain.Entities.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Members");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "123 Main St",
                            CreateDateTime = new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7136),
                            Name = "John Smith",
                            Phone = "123-456-7890",
                            UpdateDateTime = new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7137)
                        },
                        new
                        {
                            Id = 2,
                            Address = "456 Park Ave",
                            CreateDateTime = new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7139),
                            Name = "Jane Doe",
                            Phone = "456-789-0123",
                            UpdateDateTime = new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7139)
                        },
                        new
                        {
                            Id = 3,
                            Address = "789 Main St",
                            CreateDateTime = new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7140),
                            Name = "Ahmet Yılmaz",
                            Phone = "789-123-4567",
                            UpdateDateTime = new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7141)
                        },
                        new
                        {
                            Id = 4,
                            Address = "246 Park Ave",
                            CreateDateTime = new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7142),
                            Name = "Fatma Öztürk",
                            Phone = "246-789-0123",
                            UpdateDateTime = new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7143)
                        },
                        new
                        {
                            Id = 5,
                            Address = "369 Main St",
                            CreateDateTime = new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7144),
                            Name = "Mehmet Kaya",
                            Phone = "369-123-4567",
                            UpdateDateTime = new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7144)
                        });
                });

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.HasOne("TIMCaseStudy.Domain.Entities.Author", null)
                        .WithMany()
                        .HasForeignKey("AuthorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TIMCaseStudy.Domain.Entities.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TIMCaseStudy.Domain.Entities.Book", b =>
                {
                    b.HasOne("TIMCaseStudy.Domain.Entities.Category", "Category")
                        .WithMany("Books")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("TIMCaseStudy.Domain.Entities.BookTransaction", b =>
                {
                    b.HasOne("TIMCaseStudy.Domain.Entities.Book", "Book")
                        .WithMany("BookTransactions")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TIMCaseStudy.Domain.Entities.Member", "Member")
                        .WithMany("BookTransactions")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("TIMCaseStudy.Domain.Entities.Book", b =>
                {
                    b.Navigation("BookTransactions");
                });

            modelBuilder.Entity("TIMCaseStudy.Domain.Entities.Category", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("TIMCaseStudy.Domain.Entities.Member", b =>
                {
                    b.Navigation("BookTransactions");
                });
#pragma warning restore 612, 618
        }
    }
}
