using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanionCove.Infrastructure.Migrations
{
    public partial class UserExtended : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e77334c2-788a-493b-b05f-e84535e4be31", "", "", "AQAAAAEAACcQAAAAEKENUdXlHBhcYNWMUEFcA9CmzdbRo1jdT7PT96X58tkzzcu13gj6uHvmuRSlfr7V/g==", "bc20d722-3437-46b5-91e7-83da6c3ebd32" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dbc9daab-95b9-4d09-a0e7-43b6aa788b8a", "", "", "AQAAAAEAACcQAAAAEFLwDuhHezwbwlXa2f1GzuxFSo+11+eyCtsGZnNC86u2V5Pc030V2kNt7qeMwB7IbQ==", "6ea903bb-7612-4ced-b6e0-4701a47d1036" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "129f42c9-be91-471b-870d-7a5839f0744b", "AQAAAAEAACcQAAAAEA7P37WPvlyV7rxvgwG4Ei1z920sUPXX4YAdaxXxl8YIsSDt5KlCzao9JMKQfZkwqQ==", "c0963378-e47f-4bea-af6f-2a534bc814e7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "21d32996-dc03-4e3d-9cbd-f3b97a2dc44d", "AQAAAAEAACcQAAAAEETiMVwuA7JIdmwniK1qFGrTwk/CN4l//NJDYgRw6ZH5lHT4ATpklGb3R0f8U7ScKQ==", "d581e8f3-2349-4e0c-9343-dd2cb6a02e31" });
        }
    }
}
