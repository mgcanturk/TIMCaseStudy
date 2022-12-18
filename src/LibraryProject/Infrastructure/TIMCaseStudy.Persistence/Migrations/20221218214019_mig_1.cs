using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TIMCaseStudy.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Publisher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuthorBook",
                columns: table => new
                {
                    AuthorsId = table.Column<int>(type: "int", nullable: false),
                    BooksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorBook", x => new { x.AuthorsId, x.BooksId });
                    table.ForeignKey(
                        name: "FK_AuthorBook_Authors_AuthorsId",
                        column: x => x.AuthorsId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorBook_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    RetrieveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsLate = table.Column<bool>(type: "bit", nullable: false),
                    LateDay = table.Column<int>(type: "int", nullable: false),
                    Penalty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookTransactions_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookTransactions_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "CreateDateTime", "NameSurname", "UpdateDateTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 12, 19, 0, 40, 18, 697, DateTimeKind.Local).AddTicks(8111), "Jane Austen", new DateTime(2022, 12, 19, 0, 40, 18, 697, DateTimeKind.Local).AddTicks(8121) },
                    { 2, new DateTime(2022, 12, 19, 0, 40, 18, 697, DateTimeKind.Local).AddTicks(8124), "William Shakespeare", new DateTime(2022, 12, 19, 0, 40, 18, 697, DateTimeKind.Local).AddTicks(8124) },
                    { 3, new DateTime(2022, 12, 19, 0, 40, 18, 697, DateTimeKind.Local).AddTicks(8125), "Charles Dickens", new DateTime(2022, 12, 19, 0, 40, 18, 697, DateTimeKind.Local).AddTicks(8126) },
                    { 4, new DateTime(2022, 12, 19, 0, 40, 18, 697, DateTimeKind.Local).AddTicks(8127), "Mark Twain", new DateTime(2022, 12, 19, 0, 40, 18, 697, DateTimeKind.Local).AddTicks(8128) },
                    { 5, new DateTime(2022, 12, 19, 0, 40, 18, 697, DateTimeKind.Local).AddTicks(8129), "Oscar Wilde", new DateTime(2022, 12, 19, 0, 40, 18, 697, DateTimeKind.Local).AddTicks(8130) }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreateDateTime", "Name", "UpdateDateTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 12, 19, 0, 40, 18, 697, DateTimeKind.Local).AddTicks(8309), "Roman", new DateTime(2022, 12, 19, 0, 40, 18, 697, DateTimeKind.Local).AddTicks(8310) },
                    { 2, new DateTime(2022, 12, 19, 0, 40, 18, 697, DateTimeKind.Local).AddTicks(8313), "Dram", new DateTime(2022, 12, 19, 0, 40, 18, 697, DateTimeKind.Local).AddTicks(8313) },
                    { 3, new DateTime(2022, 12, 19, 0, 40, 18, 697, DateTimeKind.Local).AddTicks(8314), "Tarih", new DateTime(2022, 12, 19, 0, 40, 18, 697, DateTimeKind.Local).AddTicks(8315) },
                    { 4, new DateTime(2022, 12, 19, 0, 40, 18, 697, DateTimeKind.Local).AddTicks(8316), "Bilim Kurgu", new DateTime(2022, 12, 19, 0, 40, 18, 697, DateTimeKind.Local).AddTicks(8317) },
                    { 5, new DateTime(2022, 12, 19, 0, 40, 18, 697, DateTimeKind.Local).AddTicks(8318), "Çocuk Kitabı", new DateTime(2022, 12, 19, 0, 40, 18, 697, DateTimeKind.Local).AddTicks(8318) }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "Address", "CreateDateTime", "Name", "Phone", "UpdateDateTime" },
                values: new object[,]
                {
                    { 1, "123 Main St", new DateTime(2022, 12, 19, 0, 40, 18, 697, DateTimeKind.Local).AddTicks(8380), "John Smith", "123-456-7890", new DateTime(2022, 12, 19, 0, 40, 18, 697, DateTimeKind.Local).AddTicks(8381) },
                    { 2, "456 Park Ave", new DateTime(2022, 12, 19, 0, 40, 18, 697, DateTimeKind.Local).AddTicks(8383), "Jane Doe", "456-789-0123", new DateTime(2022, 12, 19, 0, 40, 18, 697, DateTimeKind.Local).AddTicks(8384) },
                    { 3, "789 Main St", new DateTime(2022, 12, 19, 0, 40, 18, 697, DateTimeKind.Local).AddTicks(8385), "Ahmet Yılmaz", "789-123-4567", new DateTime(2022, 12, 19, 0, 40, 18, 697, DateTimeKind.Local).AddTicks(8385) },
                    { 4, "246 Park Ave", new DateTime(2022, 12, 19, 0, 40, 18, 697, DateTimeKind.Local).AddTicks(8387), "Fatma Öztürk", "246-789-0123", new DateTime(2022, 12, 19, 0, 40, 18, 697, DateTimeKind.Local).AddTicks(8387) },
                    { 5, "369 Main St", new DateTime(2022, 12, 19, 0, 40, 18, 697, DateTimeKind.Local).AddTicks(8388), "Mehmet Kaya", "369-123-4567", new DateTime(2022, 12, 19, 0, 40, 18, 697, DateTimeKind.Local).AddTicks(8389) }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "CategoryId", "CreateDateTime", "ISBN", "IsAvailable", "Name", "Publisher", "UpdateDateTime" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 12, 19, 0, 40, 18, 697, DateTimeKind.Local).AddTicks(8345), "1234567890", true, "Gurur ve Önyargı", "Penguin Klasikleri", new DateTime(2022, 12, 19, 0, 40, 18, 697, DateTimeKind.Local).AddTicks(8346) },
                    { 2, 2, new DateTime(2022, 12, 19, 0, 40, 18, 697, DateTimeKind.Local).AddTicks(8347), "2345678901", true, "Hamlet", "Folger Shakespeare Library", new DateTime(2022, 12, 19, 0, 40, 18, 697, DateTimeKind.Local).AddTicks(8348) },
                    { 3, 1, new DateTime(2022, 12, 19, 0, 40, 18, 697, DateTimeKind.Local).AddTicks(8350), "3456789012", true, "Tale of Two Cities", "Penguin Classics", new DateTime(2022, 12, 19, 0, 40, 18, 697, DateTimeKind.Local).AddTicks(8351) },
                    { 4, 1, new DateTime(2022, 12, 19, 0, 40, 18, 697, DateTimeKind.Local).AddTicks(8353), "4567890123", true, "The Adventures of Tom Sawyer", "Penguin Classics", new DateTime(2022, 12, 19, 0, 40, 18, 697, DateTimeKind.Local).AddTicks(8353) },
                    { 5, 1, new DateTime(2022, 12, 19, 0, 40, 18, 697, DateTimeKind.Local).AddTicks(8355), "5678901234", true, "The Picture of Dorian Gray", "Penguin Classics", new DateTime(2022, 12, 19, 0, 40, 18, 697, DateTimeKind.Local).AddTicks(8355) }
                });

            migrationBuilder.InsertData(
                table: "BookTransactions",
                columns: new[] { "Id", "BookId", "CreateDateTime", "IsLate", "LateDay", "MemberId", "Penalty", "RetrieveDate", "ReturnDate", "UpdateDateTime" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 12, 19, 0, 40, 18, 697, DateTimeKind.Local).AddTicks(8419), false, 0, 1, 0m, new DateTime(2022, 10, 30, 0, 40, 18, 697, DateTimeKind.Local).AddTicks(8411), new DateTime(2022, 12, 21, 0, 40, 18, 697, DateTimeKind.Local).AddTicks(8417), new DateTime(2022, 12, 19, 0, 40, 18, 697, DateTimeKind.Local).AddTicks(8420) },
                    { 2, 2, new DateTime(2022, 12, 19, 0, 40, 18, 697, DateTimeKind.Local).AddTicks(8424), false, 0, 2, 0m, new DateTime(2022, 10, 20, 0, 40, 18, 697, DateTimeKind.Local).AddTicks(8421), new DateTime(2022, 12, 9, 0, 40, 18, 697, DateTimeKind.Local).AddTicks(8422), new DateTime(2022, 12, 19, 0, 40, 18, 697, DateTimeKind.Local).AddTicks(8424) },
                    { 3, 3, new DateTime(2022, 12, 19, 0, 40, 18, 697, DateTimeKind.Local).AddTicks(8427), false, 0, 3, 0m, new DateTime(2022, 12, 19, 0, 40, 18, 697, DateTimeKind.Local).AddTicks(8425), new DateTime(2022, 12, 20, 0, 40, 18, 697, DateTimeKind.Local).AddTicks(8426), new DateTime(2022, 12, 19, 0, 40, 18, 697, DateTimeKind.Local).AddTicks(8427) },
                    { 4, 4, new DateTime(2022, 12, 19, 0, 40, 18, 697, DateTimeKind.Local).AddTicks(8430), false, 0, 4, 0m, new DateTime(2022, 12, 19, 0, 40, 18, 697, DateTimeKind.Local).AddTicks(8428), new DateTime(2022, 12, 14, 0, 40, 18, 697, DateTimeKind.Local).AddTicks(8429), new DateTime(2022, 12, 19, 0, 40, 18, 697, DateTimeKind.Local).AddTicks(8430) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBook_BooksId",
                table: "AuthorBook",
                column: "BooksId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BookTransactions_BookId",
                table: "BookTransactions",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookTransactions_MemberId",
                table: "BookTransactions",
                column: "MemberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorBook");

            migrationBuilder.DropTable(
                name: "BookTransactions");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
