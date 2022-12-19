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
                    { 1, new DateTime(2022, 12, 19, 17, 35, 45, 60, DateTimeKind.Local).AddTicks(2342), "Jane Austen", new DateTime(2022, 12, 19, 17, 35, 45, 60, DateTimeKind.Local).AddTicks(2356) },
                    { 2, new DateTime(2022, 12, 19, 17, 35, 45, 60, DateTimeKind.Local).AddTicks(2361), "William Shakespeare", new DateTime(2022, 12, 19, 17, 35, 45, 60, DateTimeKind.Local).AddTicks(2362) },
                    { 3, new DateTime(2022, 12, 19, 17, 35, 45, 60, DateTimeKind.Local).AddTicks(2364), "Charles Dickens", new DateTime(2022, 12, 19, 17, 35, 45, 60, DateTimeKind.Local).AddTicks(2364) },
                    { 4, new DateTime(2022, 12, 19, 17, 35, 45, 60, DateTimeKind.Local).AddTicks(2366), "Mark Twain", new DateTime(2022, 12, 19, 17, 35, 45, 60, DateTimeKind.Local).AddTicks(2366) },
                    { 5, new DateTime(2022, 12, 19, 17, 35, 45, 60, DateTimeKind.Local).AddTicks(2367), "Oscar Wilde", new DateTime(2022, 12, 19, 17, 35, 45, 60, DateTimeKind.Local).AddTicks(2368) }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreateDateTime", "Name", "UpdateDateTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 12, 19, 17, 35, 45, 60, DateTimeKind.Local).AddTicks(2538), "Roman", new DateTime(2022, 12, 19, 17, 35, 45, 60, DateTimeKind.Local).AddTicks(2540) },
                    { 2, new DateTime(2022, 12, 19, 17, 35, 45, 60, DateTimeKind.Local).AddTicks(2544), "Dram", new DateTime(2022, 12, 19, 17, 35, 45, 60, DateTimeKind.Local).AddTicks(2545) },
                    { 3, new DateTime(2022, 12, 19, 17, 35, 45, 60, DateTimeKind.Local).AddTicks(2546), "Tarih", new DateTime(2022, 12, 19, 17, 35, 45, 60, DateTimeKind.Local).AddTicks(2547) },
                    { 4, new DateTime(2022, 12, 19, 17, 35, 45, 60, DateTimeKind.Local).AddTicks(2548), "Bilim Kurgu", new DateTime(2022, 12, 19, 17, 35, 45, 60, DateTimeKind.Local).AddTicks(2549) },
                    { 5, new DateTime(2022, 12, 19, 17, 35, 45, 60, DateTimeKind.Local).AddTicks(2550), "Çocuk Kitabı", new DateTime(2022, 12, 19, 17, 35, 45, 60, DateTimeKind.Local).AddTicks(2550) }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "Address", "CreateDateTime", "Name", "Phone", "UpdateDateTime" },
                values: new object[,]
                {
                    { 1, "123 Main St", new DateTime(2022, 12, 19, 17, 35, 45, 60, DateTimeKind.Local).AddTicks(2615), "John Smith", "123-456-7890", new DateTime(2022, 12, 19, 17, 35, 45, 60, DateTimeKind.Local).AddTicks(2616) },
                    { 2, "456 Park Ave", new DateTime(2022, 12, 19, 17, 35, 45, 60, DateTimeKind.Local).AddTicks(2619), "Jane Doe", "456-789-0123", new DateTime(2022, 12, 19, 17, 35, 45, 60, DateTimeKind.Local).AddTicks(2619) },
                    { 3, "789 Main St", new DateTime(2022, 12, 19, 17, 35, 45, 60, DateTimeKind.Local).AddTicks(2623), "Ahmet Yılmaz", "789-123-4567", new DateTime(2022, 12, 19, 17, 35, 45, 60, DateTimeKind.Local).AddTicks(2623) },
                    { 4, "246 Park Ave", new DateTime(2022, 12, 19, 17, 35, 45, 60, DateTimeKind.Local).AddTicks(2625), "Fatma Öztürk", "246-789-0123", new DateTime(2022, 12, 19, 17, 35, 45, 60, DateTimeKind.Local).AddTicks(2625) },
                    { 5, "369 Main St", new DateTime(2022, 12, 19, 17, 35, 45, 60, DateTimeKind.Local).AddTicks(2627), "Mehmet Kaya", "369-123-4567", new DateTime(2022, 12, 19, 17, 35, 45, 60, DateTimeKind.Local).AddTicks(2628) }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "CategoryId", "CreateDateTime", "ISBN", "IsAvailable", "Name", "Publisher", "UpdateDateTime" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 12, 19, 17, 35, 45, 60, DateTimeKind.Local).AddTicks(2576), "1234567890", true, "Gurur ve Önyargı", "Penguin Klasikleri", new DateTime(2022, 12, 19, 17, 35, 45, 60, DateTimeKind.Local).AddTicks(2577) },
                    { 2, 2, new DateTime(2022, 12, 19, 17, 35, 45, 60, DateTimeKind.Local).AddTicks(2580), "2345678901", true, "Hamlet", "Folger Shakespeare Library", new DateTime(2022, 12, 19, 17, 35, 45, 60, DateTimeKind.Local).AddTicks(2580) },
                    { 3, 1, new DateTime(2022, 12, 19, 17, 35, 45, 60, DateTimeKind.Local).AddTicks(2582), "3456789012", true, "Tale of Two Cities", "Penguin Classics", new DateTime(2022, 12, 19, 17, 35, 45, 60, DateTimeKind.Local).AddTicks(2583) },
                    { 4, 1, new DateTime(2022, 12, 19, 17, 35, 45, 60, DateTimeKind.Local).AddTicks(2584), "4567890123", true, "The Adventures of Tom Sawyer", "Penguin Classics", new DateTime(2022, 12, 19, 17, 35, 45, 60, DateTimeKind.Local).AddTicks(2585) },
                    { 5, 1, new DateTime(2022, 12, 19, 17, 35, 45, 60, DateTimeKind.Local).AddTicks(2586), "5678901234", true, "The Picture of Dorian Gray", "Penguin Classics", new DateTime(2022, 12, 19, 17, 35, 45, 60, DateTimeKind.Local).AddTicks(2587) }
                });

            migrationBuilder.InsertData(
                table: "BookTransactions",
                columns: new[] { "Id", "BookId", "CreateDateTime", "IsLate", "IsReturn", "LateDay", "MemberId", "Penalty", "RetrieveDate", "ReturnDate", "UpdateDateTime" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 12, 19, 17, 35, 45, 60, DateTimeKind.Local).AddTicks(2660), false, false, 0, 1, 0m, new DateTime(2022, 10, 30, 17, 35, 45, 60, DateTimeKind.Local).AddTicks(2651), new DateTime(2022, 12, 21, 17, 35, 45, 60, DateTimeKind.Local).AddTicks(2656), new DateTime(2022, 12, 19, 17, 35, 45, 60, DateTimeKind.Local).AddTicks(2661) },
                    { 2, 2, new DateTime(2022, 12, 19, 17, 35, 45, 60, DateTimeKind.Local).AddTicks(2665), false, false, 0, 2, 0m, new DateTime(2022, 10, 20, 17, 35, 45, 60, DateTimeKind.Local).AddTicks(2662), new DateTime(2022, 12, 9, 17, 35, 45, 60, DateTimeKind.Local).AddTicks(2663), new DateTime(2022, 12, 19, 17, 35, 45, 60, DateTimeKind.Local).AddTicks(2666) },
                    { 3, 3, new DateTime(2022, 12, 19, 17, 35, 45, 60, DateTimeKind.Local).AddTicks(2668), false, false, 0, 3, 0m, new DateTime(2022, 12, 19, 17, 35, 45, 60, DateTimeKind.Local).AddTicks(2667), new DateTime(2022, 12, 20, 17, 35, 45, 60, DateTimeKind.Local).AddTicks(2667), new DateTime(2022, 12, 19, 17, 35, 45, 60, DateTimeKind.Local).AddTicks(2669) },
                    { 4, 4, new DateTime(2022, 12, 19, 17, 35, 45, 60, DateTimeKind.Local).AddTicks(2672), false, false, 0, 4, 0m, new DateTime(2022, 12, 19, 17, 35, 45, 60, DateTimeKind.Local).AddTicks(2670), new DateTime(2022, 12, 14, 17, 35, 45, 60, DateTimeKind.Local).AddTicks(2671), new DateTime(2022, 12, 19, 17, 35, 45, 60, DateTimeKind.Local).AddTicks(2673) }
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
