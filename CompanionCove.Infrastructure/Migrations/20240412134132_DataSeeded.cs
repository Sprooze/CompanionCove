using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanionCove.Infrastructure.Migrations
{
    public partial class DataSeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 0, "1959f021-a31c-418d-b4d1-da0c760fe399", "guest@mail.com", false, false, null, "guest@mail.com", "guest@mail.com", "AQAAAAEAACcQAAAAEJ6fJs0e5Tk8zSJfU5CCgS+lgCiI9Gzz+/bbZWtsEQU4boXirXJBHtrvWdDRitzchw==", null, false, "3315080a-2e37-4a2f-9e02-cc80e4698f90", false, "guest@mail.com" },
                    { "dea12856-c198-4129-b3f3-b893d8395082", 0, "fac7b691-6811-4074-9102-0677fc002fbb", "agent@mail.com", false, false, null, "agent@mail.com", "agent@mail.com", "AQAAAAEAACcQAAAAEFTvnIXi0/GNGt5DDOCdsryoeESoP1lE7u01TSUaljUlVBApJnbdznRfyOqFpjijAA==", null, false, "e8e578bb-128c-4e14-beb0-09e2c8c025f7", false, "agent@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Dog" },
                    { 2, "Cat" },
                    { 3, "Bird" },
                    { 4, "Exotic" }
                });

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { 1, "+359888888888", "dea12856-c198-4129-b3f3-b893d8395082" });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "Address", "AgentId", "Description", "GuardianId", "ImageUrl", "Name", "TypeId" },
                values: new object[] { 1, "North London, UK (near the border)", 1, "Cute and loving female cat. 2 years old. Sleeps all day long so dont worry!", "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSthKCywFxFjV-2LHpE0xXIIBvgWyGRoQ1_fA&usqp=CAU", "Katy", 2 });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "Address", "AgentId", "Description", "GuardianId", "ImageUrl", "Name", "TypeId" },
                values: new object[] { 2, "Bulgaria, Sofia, Lozenec neighborhood", 1, "Playful 4 years old male dog, he will alwaays acompany you when you have to go somewhere!", null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR_5ElLfEoTtQIyOm38WiEMesfB6mUaP8Dl6g&usqp=CAU", "Grisho", 1 });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "Address", "AgentId", "Description", "GuardianId", "ImageUrl", "Name", "TypeId" },
                values: new object[] { 3, "Bulgaria, Pazardzhik, Mladost neighborhood", 1, "A very friendly female snake. 1 year old. Will keep you warm at night!", null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRfeW8OwQhInDF9G4f-eOFGfISWdUsy0ZaUsw&usqp=CAU", "Skizy", 4 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e");

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082");
        }
    }
}
