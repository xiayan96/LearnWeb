using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LearnWeb.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Account", "AccountType", "DateCreated" },
                values: new object[,]
                {
                    { new Guid("366e7cf5-b11e-4148-9ade-3b8d60861120"), "dc2021", "Free", new DateTime(2024, 5, 21, 21, 52, 57, 241, DateTimeKind.Local).AddTicks(3440) },
                    { new Guid("c6083db3-e67c-459d-8e4a-0e62e5850066"), "mw2021", "Free", new DateTime(2024, 5, 21, 21, 52, 57, 241, DateTimeKind.Local).AddTicks(3425) }
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Classes", "DateCreated", "Level", "Nickname", "PlayerId" },
                values: new object[,]
                {
                    { new Guid("225af06c-52d0-4c28-a35d-d959f9cd9172"), "Druid", new DateTime(2024, 5, 21, 21, 52, 57, 241, DateTimeKind.Local).AddTicks(5062), 80, "Spider Man", new Guid("c6083db3-e67c-459d-8e4a-0e62e5850066") },
                    { new Guid("a8b61ec8-5ba6-462c-90be-adf6d4be384f"), "Mage", new DateTime(2024, 5, 21, 21, 52, 57, 241, DateTimeKind.Local).AddTicks(4834), 99, "Code Man", new Guid("c6083db3-e67c-459d-8e4a-0e62e5850066") },
                    { new Guid("a99c98d2-9fa9-4106-ad99-42b9f44cb062"), "Death Knight", new DateTime(2024, 5, 21, 21, 52, 57, 241, DateTimeKind.Local).AddTicks(5065), 90, "Batman", new Guid("366e7cf5-b11e-4148-9ade-3b8d60861120") },
                    { new Guid("bf0e43a2-55ea-4cd3-8680-9a35da6cc6eb"), "Warrior", new DateTime(2024, 5, 21, 21, 52, 57, 241, DateTimeKind.Local).AddTicks(5058), 90, "Iron Man", new Guid("c6083db3-e67c-459d-8e4a-0e62e5850066") },
                    { new Guid("f15dfc25-eca5-4124-af1d-a7490930eb54"), "paladin", new DateTime(2024, 5, 21, 21, 52, 57, 241, DateTimeKind.Local).AddTicks(5067), 99, "Superman", new Guid("366e7cf5-b11e-4148-9ade-3b8d60861120") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: new Guid("225af06c-52d0-4c28-a35d-d959f9cd9172"));

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: new Guid("a8b61ec8-5ba6-462c-90be-adf6d4be384f"));

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: new Guid("a99c98d2-9fa9-4106-ad99-42b9f44cb062"));

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: new Guid("bf0e43a2-55ea-4cd3-8680-9a35da6cc6eb"));

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: new Guid("f15dfc25-eca5-4124-af1d-a7490930eb54"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("366e7cf5-b11e-4148-9ade-3b8d60861120"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("c6083db3-e67c-459d-8e4a-0e62e5850066"));
        }
    }
}
