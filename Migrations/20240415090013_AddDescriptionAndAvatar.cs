using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoneProject.Migrations
{
    /// <inheritdoc />
    public partial class AddDescriptionAndAvatar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "Phones",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Phones",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "Phones");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Phones");
        }
    }
}
