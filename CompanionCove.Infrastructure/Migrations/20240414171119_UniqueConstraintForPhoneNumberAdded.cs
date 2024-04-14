using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanionCove.Infrastructure.Migrations
{
    public partial class UniqueConstraintForPhoneNumberAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_Agents_PhoneNumber",
                table: "Agents",
                column: "PhoneNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Agents_PhoneNumber",
                table: "Agents");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1959f021-a31c-418d-b4d1-da0c760fe399", "AQAAAAEAACcQAAAAEJ6fJs0e5Tk8zSJfU5CCgS+lgCiI9Gzz+/bbZWtsEQU4boXirXJBHtrvWdDRitzchw==", "3315080a-2e37-4a2f-9e02-cc80e4698f90" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fac7b691-6811-4074-9102-0677fc002fbb", "AQAAAAEAACcQAAAAEFTvnIXi0/GNGt5DDOCdsryoeESoP1lE7u01TSUaljUlVBApJnbdznRfyOqFpjijAA==", "e8e578bb-128c-4e14-beb0-09e2c8c025f7" });
        }
    }
}
