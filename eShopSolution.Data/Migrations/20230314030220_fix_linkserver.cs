using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopSolution.Data.Migrations
{
    public partial class fix_linkserver : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "bad3dc0f-da15-4c23-81e2-fcad635274df");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e75373d0-1f96-4889-8c93-1eb4723069fc", "AQAAAAEAACcQAAAAEKHAOcSSajGYnyTROSRn9kaBazIZ5ktiKcqbt7QxDywaPuRHZPb4GqYFnTO9FiYFbg==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 3, 14, 10, 2, 19, 205, DateTimeKind.Local).AddTicks(2388));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "dc37efa2-5f55-466a-919b-52d02e310f6c", "AQAAAAEAACcQAAAAEGzpy65duXr6XebpZ8LGNuGkk5sDqnY0l16SjQVHpxgT7xlzfBiqwSKdkkjjp6Qtbw==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 3, 13, 22, 17, 49, 375, DateTimeKind.Local).AddTicks(1411));
        }
    }
}
