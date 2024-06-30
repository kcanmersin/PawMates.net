using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PawMates.net.Migrations
{
    /// <inheritdoc />
    public partial class AddImageUrlsToPet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b92b3baf-eeb8-4cd6-a79b-760bb76ba5b4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f57bfc51-d6af-4310-b469-69e932d8b127");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrls",
                table: "Pets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BackgroundPictureUrl",
                table: "AspNetUsers",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProfilePictureUrl",
                table: "AspNetUsers",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8923131c-71f1-4813-a984-81ea16ea6bc5", null, "Admin", "ADMIN" },
                    { "dc137c6f-5652-472e-baa0-110082db20ad", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8923131c-71f1-4813-a984-81ea16ea6bc5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dc137c6f-5652-472e-baa0-110082db20ad");

            migrationBuilder.DropColumn(
                name: "ImageUrls",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "BackgroundPictureUrl",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProfilePictureUrl",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b92b3baf-eeb8-4cd6-a79b-760bb76ba5b4", null, "User", "USER" },
                    { "f57bfc51-d6af-4310-b469-69e932d8b127", null, "Admin", "ADMIN" }
                });
        }
    }
}
