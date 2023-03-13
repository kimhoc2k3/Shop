using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopSolution.Data.Migrations
{
    public partial class SeedIdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "75d1a152-e47f-4ddd-86ff-d5311510bd53");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "Email", "FirstName", "LastName", "NormalizedEmail", "PasswordHash" },
                values: new object[] { "dc37efa2-5f55-466a-919b-52d02e310f6c", "hq37na@gmail.com", "Hoc", "Nguyen", "hq37na@gmail.com", "AQAAAAEAACcQAAAAEGzpy65duXr6XebpZ8LGNuGkk5sDqnY0l16SjQVHpxgT7xlzfBiqwSKdkkjjp6Qtbw==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 3, 13, 22, 17, 49, 375, DateTimeKind.Local).AddTicks(1411));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "7a639dd6-f3d6-4123-a464-a437c424a351");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "Email", "FirstName", "LastName", "NormalizedEmail", "PasswordHash" },
                values: new object[] { "e8382f96-364b-4f4d-8b55-4ec2b04ceec5", "tedu.international@gmail.com", "Toan", "Bach", "tedu.international@gmail.com", "AQAAAAEAACcQAAAAEIBwA0XpSExz6LyiKdtHIsoKd/k7hBwruUHqirenDi91xXvZoraOXwPYkhcujG7W0A==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 3, 13, 22, 6, 24, 475, DateTimeKind.Local).AddTicks(6974));
        }
    }
}
