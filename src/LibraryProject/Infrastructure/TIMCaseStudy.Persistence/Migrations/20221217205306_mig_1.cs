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
                    NameSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ISBN = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_BookTransactions_Books_ISBN",
                        column: x => x.ISBN,
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
                    { 1, new DateTime(2022, 12, 17, 23, 53, 6, 699, DateTimeKind.Local).AddTicks(1088), "Sabahattin Ali", new DateTime(2022, 12, 17, 23, 53, 6, 699, DateTimeKind.Local).AddTicks(1089) },
                    { 2, new DateTime(2022, 12, 17, 23, 53, 6, 699, DateTimeKind.Local).AddTicks(1090), "Stefan Zweig", new DateTime(2022, 12, 17, 23, 53, 6, 699, DateTimeKind.Local).AddTicks(1091) },
                    { 3, new DateTime(2022, 12, 17, 23, 53, 6, 699, DateTimeKind.Local).AddTicks(1092), "Yaşar Kemal", new DateTime(2022, 12, 17, 23, 53, 6, 699, DateTimeKind.Local).AddTicks(1093) },
                    { 4, new DateTime(2022, 12, 17, 23, 53, 6, 699, DateTimeKind.Local).AddTicks(1094), "Doğan Cüceloğlu", new DateTime(2022, 12, 17, 23, 53, 6, 699, DateTimeKind.Local).AddTicks(1094) },
                    { 5, new DateTime(2022, 12, 17, 23, 53, 6, 699, DateTimeKind.Local).AddTicks(1095), "Şermin Yaşar", new DateTime(2022, 12, 17, 23, 53, 6, 699, DateTimeKind.Local).AddTicks(1096) }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreateDateTime", "Name", "UpdateDateTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 12, 17, 23, 53, 6, 699, DateTimeKind.Local).AddTicks(881), "Roman", new DateTime(2022, 12, 17, 23, 53, 6, 699, DateTimeKind.Local).AddTicks(891) },
                    { 2, new DateTime(2022, 12, 17, 23, 53, 6, 699, DateTimeKind.Local).AddTicks(893), "Hikaye", new DateTime(2022, 12, 17, 23, 53, 6, 699, DateTimeKind.Local).AddTicks(894) },
                    { 3, new DateTime(2022, 12, 17, 23, 53, 6, 699, DateTimeKind.Local).AddTicks(895), "Tarih", new DateTime(2022, 12, 17, 23, 53, 6, 699, DateTimeKind.Local).AddTicks(895) },
                    { 4, new DateTime(2022, 12, 17, 23, 53, 6, 699, DateTimeKind.Local).AddTicks(896), "Bilim Kurgu", new DateTime(2022, 12, 17, 23, 53, 6, 699, DateTimeKind.Local).AddTicks(897) },
                    { 5, new DateTime(2022, 12, 17, 23, 53, 6, 699, DateTimeKind.Local).AddTicks(898), "Korku", new DateTime(2022, 12, 17, 23, 53, 6, 699, DateTimeKind.Local).AddTicks(898) },
                    { 6, new DateTime(2022, 12, 17, 23, 53, 6, 699, DateTimeKind.Local).AddTicks(899), "Polisiye", new DateTime(2022, 12, 17, 23, 53, 6, 699, DateTimeKind.Local).AddTicks(901) },
                    { 7, new DateTime(2022, 12, 17, 23, 53, 6, 699, DateTimeKind.Local).AddTicks(902), "Psikoloji", new DateTime(2022, 12, 17, 23, 53, 6, 699, DateTimeKind.Local).AddTicks(902) },
                    { 8, new DateTime(2022, 12, 17, 23, 53, 6, 699, DateTimeKind.Local).AddTicks(903), "Fantastik", new DateTime(2022, 12, 17, 23, 53, 6, 699, DateTimeKind.Local).AddTicks(904) },
                    { 9, new DateTime(2022, 12, 17, 23, 53, 6, 699, DateTimeKind.Local).AddTicks(905), "Kişisel Gelişim", new DateTime(2022, 12, 17, 23, 53, 6, 699, DateTimeKind.Local).AddTicks(906) },
                    { 10, new DateTime(2022, 1, 8, 12, 0, 0, 0, DateTimeKind.Unspecified), "Edebiyat", new DateTime(2022, 1, 8, 12, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "Age", "City", "CreateDateTime", "NameSurname", "UpdateDateTime" },
                values: new object[,]
                {
                    { 1, 25, "İstanbul", new DateTime(2022, 12, 17, 23, 53, 6, 699, DateTimeKind.Local).AddTicks(1060), "Ali Kırkpınar", new DateTime(2022, 12, 17, 23, 53, 6, 699, DateTimeKind.Local).AddTicks(1061) },
                    { 2, 32, "İstanbul", new DateTime(2022, 12, 17, 23, 53, 6, 699, DateTimeKind.Local).AddTicks(1064), "Veli Karapınar", new DateTime(2022, 12, 17, 23, 53, 6, 699, DateTimeKind.Local).AddTicks(1064) },
                    { 3, 23, "Ankara", new DateTime(2022, 12, 17, 23, 53, 6, 699, DateTimeKind.Local).AddTicks(1065), "Kahraman Paladin", new DateTime(2022, 12, 17, 23, 53, 6, 699, DateTimeKind.Local).AddTicks(1066) }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "CategoryId", "CreateDateTime", "ISBN", "IsAvailable", "Name", "Publisher", "UpdateDateTime" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2022, 12, 17, 23, 53, 6, 699, DateTimeKind.Local).AddTicks(1122), "1234567890", true, "Pamuk Prenses ve Yedi Cüceler", "Doğan Kitap", new DateTime(2022, 12, 17, 23, 53, 6, 699, DateTimeKind.Local).AddTicks(1123) },
                    { 2, 2, 1, new DateTime(2022, 12, 17, 23, 53, 6, 699, DateTimeKind.Local).AddTicks(1125), "1234567891", true, "Alacakaranlık", "Doğan Kitap", new DateTime(2022, 12, 17, 23, 53, 6, 699, DateTimeKind.Local).AddTicks(1125) },
                    { 3, 3, 1, new DateTime(2022, 12, 17, 23, 53, 6, 699, DateTimeKind.Local).AddTicks(1127), "1234567892", true, "Harry Potter ve Felsefe Taşı", "Pegasus Yayınları", new DateTime(2022, 12, 17, 23, 53, 6, 699, DateTimeKind.Local).AddTicks(1127) },
                    { 4, 2, 2, new DateTime(2022, 12, 17, 23, 53, 6, 699, DateTimeKind.Local).AddTicks(1129), "1234567893", true, "Yüzüklerin Efendisi: Kralın Dönüşü", "Pegasus Yayınları", new DateTime(2022, 12, 17, 23, 53, 6, 699, DateTimeKind.Local).AddTicks(1129) },
                    { 5, 1, 3, new DateTime(2022, 12, 17, 23, 53, 6, 699, DateTimeKind.Local).AddTicks(1131), "1234567894", true, "Sıradışı Öğrenciler", "Doğan Kitap", new DateTime(2022, 12, 17, 23, 53, 6, 699, DateTimeKind.Local).AddTicks(1131) },
                    { 6, 2, 3, new DateTime(2022, 12, 17, 23, 53, 6, 699, DateTimeKind.Local).AddTicks(1133), "1234567895", true, "Ormanlar Kralı", "Doğan Kitap", new DateTime(2022, 12, 17, 23, 53, 6, 699, DateTimeKind.Local).AddTicks(1133) },
                    { 7, 4, 3, new DateTime(2022, 12, 17, 23, 53, 6, 699, DateTimeKind.Local).AddTicks(1135), "1234567897", true, "Japon Edebiyatı Tarihi", "Doğan Kitap", new DateTime(2022, 12, 17, 23, 53, 6, 699, DateTimeKind.Local).AddTicks(1135) },
                    { 8, 4, 3, new DateTime(2022, 12, 17, 23, 53, 6, 699, DateTimeKind.Local).AddTicks(1137), "1234567898", true, "Tarihte İslam Dünyası", "Pegasus Yayınları", new DateTime(2022, 12, 17, 23, 53, 6, 699, DateTimeKind.Local).AddTicks(1137) },
                    { 9, 2, 2, new DateTime(2022, 12, 17, 23, 53, 6, 699, DateTimeKind.Local).AddTicks(1139), "1234567899", true, "Yunan Mitolojisi", "Doğan Kitap", new DateTime(2022, 12, 17, 23, 53, 6, 699, DateTimeKind.Local).AddTicks(1139) },
                    { 10, 1, 4, new DateTime(2022, 12, 17, 23, 53, 6, 699, DateTimeKind.Local).AddTicks(1141), "12345678910", true, "İngiliz Tarihi", "Pegasus Yayınları", new DateTime(2022, 12, 17, 23, 53, 6, 699, DateTimeKind.Local).AddTicks(1141) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BookTransactions_ISBN",
                table: "BookTransactions",
                column: "ISBN");

            migrationBuilder.CreateIndex(
                name: "IX_BookTransactions_MemberId",
                table: "BookTransactions",
                column: "MemberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookTransactions");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
