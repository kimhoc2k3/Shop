using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopSolution.Data.Migrations
{
    public partial class fixtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFeatured",
                table: "Products",
                type: "bit",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "b081d90c-9817-462c-9bb0-791a5cb68a50");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e9f766b3-6a58-4d00-bdd9-f5dd0ee5ad78", "AQAAAAEAACcQAAAAEDFRQpl0r3cxLi2wrl9Rr4dlhkN4mx4Bndn1pMnDI/0QuuSsIod8gXgol30yZErZQQ==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 4, 9, 1, 54, 55, 60, DateTimeKind.Local).AddTicks(1849));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
