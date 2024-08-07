using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo.Migrations
{
    /// <inheritdoc />
    public partial class emailNotNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "MailList",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 8, 7, 22, 58, 45, 162, DateTimeKind.Local).AddTicks(8880), new DateTime(2024, 8, 7, 22, 58, 45, 162, DateTimeKind.Local).AddTicks(8880) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 8, 7, 22, 58, 45, 162, DateTimeKind.Local).AddTicks(8890), new DateTime(2024, 8, 7, 22, 58, 45, 162, DateTimeKind.Local).AddTicks(8890) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 8, 7, 22, 58, 45, 162, DateTimeKind.Local).AddTicks(8890), new DateTime(2024, 8, 7, 22, 58, 45, 162, DateTimeKind.Local).AddTicks(8890) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 8, 7, 22, 58, 45, 162, DateTimeKind.Local).AddTicks(8890), new DateTime(2024, 8, 7, 22, 58, 45, 162, DateTimeKind.Local).AddTicks(8890) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "MailList",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 7, 28, 23, 5, 11, 860, DateTimeKind.Local).AddTicks(810), new DateTime(2024, 7, 28, 23, 5, 11, 860, DateTimeKind.Local).AddTicks(820) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 7, 28, 23, 5, 11, 860, DateTimeKind.Local).AddTicks(820), new DateTime(2024, 7, 28, 23, 5, 11, 860, DateTimeKind.Local).AddTicks(820) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 7, 28, 23, 5, 11, 860, DateTimeKind.Local).AddTicks(820), new DateTime(2024, 7, 28, 23, 5, 11, 860, DateTimeKind.Local).AddTicks(820) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 7, 28, 23, 5, 11, 860, DateTimeKind.Local).AddTicks(830), new DateTime(2024, 7, 28, 23, 5, 11, 860, DateTimeKind.Local).AddTicks(830) });
        }
    }
}
