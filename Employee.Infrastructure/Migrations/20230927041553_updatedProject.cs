using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employee.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatedProject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 9, 27, 10, 15, 53, 560, DateTimeKind.Unspecified).AddTicks(7608), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 9, 27, 10, 15, 53, 560, DateTimeKind.Unspecified).AddTicks(7645), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 9, 27, 10, 15, 53, 561, DateTimeKind.Unspecified).AddTicks(3645), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 9, 27, 10, 15, 53, 561, DateTimeKind.Unspecified).AddTicks(3657), new TimeSpan(0, 6, 0, 0, 0)) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 9, 16, 10, 45, 50, 235, DateTimeKind.Unspecified).AddTicks(9715), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 9, 16, 10, 45, 50, 235, DateTimeKind.Unspecified).AddTicks(9773), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 9, 16, 10, 45, 50, 236, DateTimeKind.Unspecified).AddTicks(6292), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 9, 16, 10, 45, 50, 236, DateTimeKind.Unspecified).AddTicks(6303), new TimeSpan(0, 6, 0, 0, 0)) });
        }
    }
}
