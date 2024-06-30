using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Demo.Migrations
{
    /// <inheritdoc />
    public partial class Dbinit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Maillists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(type: "varchar(255)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maillists", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(255)", nullable: true),
                    Description = table.Column<string>(type: "longtext", nullable: true),
                    IsRelease = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsDelete = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreateDate", "Description", "IsDelete", "IsRelease", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 27, 15, 14, 8, 495, DateTimeKind.Local).AddTicks(8370), "Shakespeare", false, true, "William", new DateTime(2024, 6, 27, 15, 14, 8, 495, DateTimeKind.Local).AddTicks(8420) },
                    { 2, new DateTime(2024, 6, 27, 15, 14, 8, 495, DateTimeKind.Local).AddTicks(8430), "Royal Gala", false, true, "Apple", new DateTime(2024, 6, 27, 15, 14, 8, 495, DateTimeKind.Local).AddTicks(8430) },
                    { 3, new DateTime(2024, 6, 27, 15, 14, 8, 495, DateTimeKind.Local).AddTicks(8430), "Australia", false, true, "Orange", new DateTime(2024, 6, 27, 15, 14, 8, 495, DateTimeKind.Local).AddTicks(8430) },
                    { 4, new DateTime(2024, 6, 27, 15, 14, 8, 495, DateTimeKind.Local).AddTicks(8430), "Filipino", false, true, "Banana", new DateTime(2024, 6, 27, 15, 14, 8, 495, DateTimeKind.Local).AddTicks(8440) }
                });

            migrationBuilder.CreateIndex(
                name: "idx_email",
                table: "Maillists",
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
                name: "Maillists");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
