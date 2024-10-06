using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccesLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddUrlForFirmDocs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "FirmDocs",
                newName: "UserID");

            migrationBuilder.AddColumn<string>(
                name: "URL",
                table: "FirmDocs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "URL",
                table: "FirmDocs");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "FirmDocs",
                newName: "ID");
        }
    }
}
