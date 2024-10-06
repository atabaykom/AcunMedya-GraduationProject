using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccesLayer.Migrations
{
    /// <inheritdoc />
    public partial class t2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FirmDocs_AspNetUsers_AppUserId",
                table: "FirmDocs");

            migrationBuilder.DropIndex(
                name: "IX_FirmDocs_AppUserId",
                table: "FirmDocs");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "FirmDocs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "FirmDocs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FirmDocs_AppUserId",
                table: "FirmDocs",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FirmDocs_AspNetUsers_AppUserId",
                table: "FirmDocs",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
