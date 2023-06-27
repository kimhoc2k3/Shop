using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopSolution.Data.Migrations
{
    public partial class add_colums : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "b7c9ea35-bedb-4929-a94f-4a2a61759f12");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "23851b0c-0e70-430a-970b-8963f5c67e51", "AQAAAAEAACcQAAAAED0NmBSL0o5VyN59qVvcT+m17lJZgOXujEVU62yvkCzVUc8lksFwPU3dS57FOhENRA==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 4, 7, 11, 41, 16, 244, DateTimeKind.Local).AddTicks(7835));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
