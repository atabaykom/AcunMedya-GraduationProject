using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccesLayer.Migrations
{
    /// <inheritdoc />
    public partial class addcontentfavoritemap2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContentFavoriteMap",
                columns: table => new
                {
                    MapId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContentID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentFavoriteMap", x => x.MapId);
                    table.ForeignKey(
                        name: "FK_ContentFavoriteMap_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContentFavoriteMap_Contents_ContentID",
                        column: x => x.ContentID,
                        principalTable: "Contents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContentFavoriteMap_ContentID",
                table: "ContentFavoriteMap",
                column: "ContentID");

            migrationBuilder.CreateIndex(
                name: "IX_ContentFavoriteMap_UserID",
                table: "ContentFavoriteMap",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContentFavoriteMap");
        }
    }
}
