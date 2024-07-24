using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo.Migrations
{
    /// <inheritdoc />
    public partial class add_description : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Maillists",
                type: "longtext",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 7, 23, 21, 37, 5, 695, DateTimeKind.Local).AddTicks(4640), new DateTime(2024, 7, 23, 21, 37, 5, 695, DateTimeKind.Local).AddTicks(4670) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 7, 23, 21, 37, 5, 695, DateTimeKind.Local).AddTicks(4670), new DateTime(2024, 7, 23, 21, 37, 5, 695, DateTimeKind.Local).AddTicks(4670) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 7, 23, 21, 37, 5, 695, DateTimeKind.Local).AddTicks(4670), new DateTime(2024, 7, 23, 21, 37, 5, 695, DateTimeKind.Local).AddTicks(4680) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 7, 23, 21, 37, 5, 695, DateTimeKind.Local).AddTicks(4680), new DateTime(2024, 7, 23, 21, 37, 5, 695, DateTimeKind.Local).AddTicks(4680) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Maillists");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 7, 23, 21, 17, 15, 149, DateTimeKind.Local).AddTicks(6080), new DateTime(2024, 7, 23, 21, 17, 15, 149, DateTimeKind.Local).AddTicks(6120) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 7, 23, 21, 17, 15, 149, DateTimeKind.Local).AddTicks(6120), new DateTime(2024, 7, 23, 21, 17, 15, 149, DateTimeKind.Local).AddTicks(6130) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 7, 23, 21, 17, 15, 149, DateTimeKind.Local).AddTicks(6130), new DateTime(2024, 7, 23, 21, 17, 15, 149, DateTimeKind.Local).AddTicks(6130) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 7, 23, 21, 17, 15, 149, DateTimeKind.Local).AddTicks(6130), new DateTime(2024, 7, 23, 21, 17, 15, 149, DateTimeKind.Local).AddTicks(6130) });
        }
    }
}
