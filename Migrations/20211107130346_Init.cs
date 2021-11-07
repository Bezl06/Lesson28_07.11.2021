using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lesson28.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Text = table.Column<string>(type: "TEXT", nullable: false),
                    Author = table.Column<string>(type: "TEXT", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "Author", "InsertDate", "Text" },
                values: new object[] { 1, "Некий Великий Ноунейм №1", new DateTime(2021, 11, 7, 18, 3, 45, 891, DateTimeKind.Local).AddTicks(311), "Цитата №1" });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "Author", "InsertDate", "Text" },
                values: new object[] { 2, "Некий Великий Ноунейм №2", new DateTime(2021, 11, 7, 18, 3, 45, 891, DateTimeKind.Local).AddTicks(321), "Цитата №2" });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "Author", "InsertDate", "Text" },
                values: new object[] { 3, "Некий Великий Ноунейм №3", new DateTime(2021, 11, 7, 18, 3, 45, 891, DateTimeKind.Local).AddTicks(322), "Цитата №3" });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "Author", "InsertDate", "Text" },
                values: new object[] { 4, "Некий Великий Ноунейм №4", new DateTime(2021, 11, 7, 18, 3, 45, 891, DateTimeKind.Local).AddTicks(323), "Цитата №4" });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "Author", "InsertDate", "Text" },
                values: new object[] { 5, "Некий Великий Ноунейм №5", new DateTime(2021, 11, 7, 18, 3, 45, 891, DateTimeKind.Local).AddTicks(324), "Цитата №5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quotes");
        }
    }
}
