using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo.Migrations
{
    /// <inheritdoc />
    public partial class add_image : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Products",
                type: "double",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "Products",
                type: "longtext",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "ImageURL", "Price", "UpdateDate" },
                values: new object[] { new DateTime(2024, 7, 23, 22, 17, 28, 379, DateTimeKind.Local).AddTicks(1260), null, null, new DateTime(2024, 7, 23, 22, 17, 28, 379, DateTimeKind.Local).AddTicks(1290) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "ImageURL", "Price", "UpdateDate" },
                values: new object[] { new DateTime(2024, 7, 23, 22, 17, 28, 379, DateTimeKind.Local).AddTicks(1290), null, null, new DateTime(2024, 7, 23, 22, 17, 28, 379, DateTimeKind.Local).AddTicks(1300) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "ImageURL", "Price", "UpdateDate" },
                values: new object[] { new DateTime(2024, 7, 23, 22, 17, 28, 379, DateTimeKind.Local).AddTicks(1300), null, null, new DateTime(2024, 7, 23, 22, 17, 28, 379, DateTimeKind.Local).AddTicks(1300) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreateDate", "ImageURL", "Price", "UpdateDate" },
                values: new object[] { new DateTime(2024, 7, 23, 22, 17, 28, 379, DateTimeKind.Local).AddTicks(1300), null, null, new DateTime(2024, 7, 23, 22, 17, 28, 379, DateTimeKind.Local).AddTicks(1300) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "Products");

            migrationBuilder.AlterColumn<float>(
                name: "Price",
                table: "Products",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "Price", "UpdateDate" },
                values: new object[] { new DateTime(2024, 7, 23, 21, 37, 5, 695, DateTimeKind.Local).AddTicks(4640), null, new DateTime(2024, 7, 23, 21, 37, 5, 695, DateTimeKind.Local).AddTicks(4670) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "Price", "UpdateDate" },
                values: new object[] { new DateTime(2024, 7, 23, 21, 37, 5, 695, DateTimeKind.Local).AddTicks(4670), null, new DateTime(2024, 7, 23, 21, 37, 5, 695, DateTimeKind.Local).AddTicks(4670) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "Price", "UpdateDate" },
                values: new object[] { new DateTime(2024, 7, 23, 21, 37, 5, 695, DateTimeKind.Local).AddTicks(4670), null, new DateTime(2024, 7, 23, 21, 37, 5, 695, DateTimeKind.Local).AddTicks(4680) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreateDate", "Price", "UpdateDate" },
                values: new object[] { new DateTime(2024, 7, 23, 21, 37, 5, 695, DateTimeKind.Local).AddTicks(4680), null, new DateTime(2024, 7, 23, 21, 37, 5, 695, DateTimeKind.Local).AddTicks(4680) });
        }
    }
}
