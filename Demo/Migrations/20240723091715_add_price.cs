using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo.Migrations
{
    /// <inheritdoc />
    public partial class add_price : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Products");

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "Products",
                type: "float",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "Price", "UpdateDate" },
                values: new object[] { new DateTime(2024, 7, 23, 21, 17, 15, 149, DateTimeKind.Local).AddTicks(6080), null, new DateTime(2024, 7, 23, 21, 17, 15, 149, DateTimeKind.Local).AddTicks(6120) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "Price", "UpdateDate" },
                values: new object[] { new DateTime(2024, 7, 23, 21, 17, 15, 149, DateTimeKind.Local).AddTicks(6120), null, new DateTime(2024, 7, 23, 21, 17, 15, 149, DateTimeKind.Local).AddTicks(6130) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "Description", "Price", "UpdateDate" },
                values: new object[] { new DateTime(2024, 7, 23, 21, 17, 15, 149, DateTimeKind.Local).AddTicks(6130), "Australian", null, new DateTime(2024, 7, 23, 21, 17, 15, 149, DateTimeKind.Local).AddTicks(6130) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreateDate", "Description", "Price", "UpdateDate" },
                values: new object[] { new DateTime(2024, 7, 23, 21, 17, 15, 149, DateTimeKind.Local).AddTicks(6130), "Philippine", null, new DateTime(2024, 7, 23, 21, 17, 15, 149, DateTimeKind.Local).AddTicks(6130) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Products",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "IsDelete", "UpdateDate" },
                values: new object[] { new DateTime(2024, 6, 27, 15, 14, 8, 495, DateTimeKind.Local).AddTicks(8370), false, new DateTime(2024, 6, 27, 15, 14, 8, 495, DateTimeKind.Local).AddTicks(8420) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "IsDelete", "UpdateDate" },
                values: new object[] { new DateTime(2024, 6, 27, 15, 14, 8, 495, DateTimeKind.Local).AddTicks(8430), false, new DateTime(2024, 6, 27, 15, 14, 8, 495, DateTimeKind.Local).AddTicks(8430) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "Description", "IsDelete", "UpdateDate" },
                values: new object[] { new DateTime(2024, 6, 27, 15, 14, 8, 495, DateTimeKind.Local).AddTicks(8430), "Australia", false, new DateTime(2024, 6, 27, 15, 14, 8, 495, DateTimeKind.Local).AddTicks(8430) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreateDate", "Description", "IsDelete", "UpdateDate" },
                values: new object[] { new DateTime(2024, 6, 27, 15, 14, 8, 495, DateTimeKind.Local).AddTicks(8430), "Filipino", false, new DateTime(2024, 6, 27, 15, 14, 8, 495, DateTimeKind.Local).AddTicks(8440) });
        }
    }
}
