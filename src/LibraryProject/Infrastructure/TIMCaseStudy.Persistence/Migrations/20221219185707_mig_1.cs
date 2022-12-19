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
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    IsReturn = table.Column<bool>(type: "bit", nullable: false),
                    IsLate = table.Column<bool>(type: "bit", nullable: false),
                    LateDay = table.Column<int>(type: "int", nullable: false),
                    Penalty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    { 1, new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(6867), "Jane Austen", new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(6878) },
                    { 2, new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(6883), "William Shakespeare", new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(6884) },
                    { 3, new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(6886), "Charles Dickens", new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(6886) },
                    { 4, new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(6888), "Mark Twain", new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(6888) },
                    { 5, new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(6889), "Oscar Wilde", new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(6890) }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreateDateTime", "Name", "UpdateDateTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7066), "Roman", new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7068) },
                    { 2, new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7070), "Dram", new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7071) },
                    { 3, new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7072), "Tarih", new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7072) },
                    { 4, new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7073), "Bilim Kurgu", new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7074) },
                    { 5, new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7075), "Çocuk Kitabı", new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7075) }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "Address", "CreateDateTime", "Name", "Phone", "UpdateDateTime" },
                values: new object[,]
                {
                    { 1, "123 Main St", new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7136), "John Smith", "123-456-7890", new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7137) },
                    { 2, "456 Park Ave", new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7139), "Jane Doe", "456-789-0123", new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7139) },
                    { 3, "789 Main St", new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7140), "Ahmet Yılmaz", "789-123-4567", new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7141) },
                    { 4, "246 Park Ave", new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7142), "Fatma Öztürk", "246-789-0123", new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7143) },
                    { 5, "369 Main St", new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7144), "Mehmet Kaya", "369-123-4567", new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7144) }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "CategoryId", "CreateDateTime", "ISBN", "IsAvailable", "Name", "Publisher", "UpdateDateTime" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7099), "1234567890", true, "Gurur ve Önyargı", "Penguin Klasikleri", new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7100) },
                    { 2, 2, new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7102), "2345678901", true, "Hamlet", "Folger Shakespeare Library", new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7103) },
                    { 3, 1, new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7105), "3456789012", true, "Tale of Two Cities", "Penguin Classics", new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7106) },
                    { 4, 1, new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7107), "4567890123", true, "The Adventures of Tom Sawyer", "Penguin Classics", new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7108) },
                    { 5, 1, new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7111), "5678901234", true, "The Picture of Dorian Gray", "Penguin Classics", new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7111) }
                });

            migrationBuilder.InsertData(
                table: "BookTransactions",
                columns: new[] { "Id", "BookId", "CreateDateTime", "IsLate", "IsReturn", "LateDay", "MemberId", "Penalty", "RetrieveDate", "ReturnDate", "UpdateDateTime" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7171), false, false, 0, 1, 0m, new DateTime(2022, 10, 30, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7163), new DateTime(2022, 12, 21, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7168), new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7171) },
                    { 2, 2, new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7175), false, false, 0, 2, 0m, new DateTime(2022, 10, 20, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7172), new DateTime(2022, 11, 29, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7173), new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7175) },
                    { 3, 3, new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7178), false, false, 0, 3, 0m, new DateTime(2022, 11, 14, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7176), new DateTime(2022, 12, 14, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7177), new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7179) },
                    { 4, 4, new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7181), false, false, 0, 4, 0m, new DateTime(2022, 12, 14, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7180), new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7181), new DateTime(2022, 12, 19, 21, 57, 7, 340, DateTimeKind.Local).AddTicks(7182) }
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
