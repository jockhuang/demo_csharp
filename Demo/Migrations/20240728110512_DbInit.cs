using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Demo.Migrations
{
    /// <inheritdoc />
    public partial class DbInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MailList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(type: "varchar(255)", nullable: true),
                    Description = table.Column<string>(type: "longtext", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailList", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true),
                    ImageURL = table.Column<string>(type: "longtext", nullable: true),
                    Price = table.Column<double>(type: "double", nullable: true),
                    IsRelease = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreateDate", "Description", "ImageURL", "IsRelease", "Name", "Price", "UpdateDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 28, 23, 5, 11, 860, DateTimeKind.Local).AddTicks(810), "Shakespeare", null, true, "William", null, new DateTime(2024, 7, 28, 23, 5, 11, 860, DateTimeKind.Local).AddTicks(820) },
                    { 2, new DateTime(2024, 7, 28, 23, 5, 11, 860, DateTimeKind.Local).AddTicks(820), "Royal Gala", null, true, "Apple", null, new DateTime(2024, 7, 28, 23, 5, 11, 860, DateTimeKind.Local).AddTicks(820) },
                    { 3, new DateTime(2024, 7, 28, 23, 5, 11, 860, DateTimeKind.Local).AddTicks(820), "Australian", null, true, "Orange", null, new DateTime(2024, 7, 28, 23, 5, 11, 860, DateTimeKind.Local).AddTicks(820) },
                    { 4, new DateTime(2024, 7, 28, 23, 5, 11, 860, DateTimeKind.Local).AddTicks(830), "Philippine", null, true, "Banana", null, new DateTime(2024, 7, 28, 23, 5, 11, 860, DateTimeKind.Local).AddTicks(830) }
                });

            migrationBuilder.CreateIndex(
                name: "idx_email",
                table: "MailList",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_product_name",
                table: "Products",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MailList");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
