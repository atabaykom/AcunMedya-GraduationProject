using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccesLayer.Migrations
{
    /// <inheritdoc />
    public partial class firstmigrationfordb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SURNAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContentCategories",
                columns: table => new
                {
                    CATEGORYID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CATNAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISACTIVE = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentCategories", x => x.CATEGORYID);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MESSAGEID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SENDERMAIL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SENDERNAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RECEIVERMAIL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RECEIVERNAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CONTENT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MESSAGEID);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    EMAILQUEUEID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TOADRESS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SUBJECT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BODY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    STATUS = table.Column<int>(type: "int", nullable: false),
                    RETRYCOUNT = table.Column<int>(type: "int", nullable: false),
                    LASTRERYDATE = table.Column<int>(type: "int", nullable: false),
                    ISDELIVERED = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.EMAILQUEUEID);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    TAGID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TAGNAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISACTIVE = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.TAGID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contents",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CATEGORYID = table.Column<int>(type: "int", nullable: false),
                    CONTENOWNERID = table.Column<int>(type: "int", nullable: false),
                    TITLE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PRICE = table.Column<int>(type: "int", nullable: false),
                    COUNTRY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CITY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TOWN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ADRESS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NUMBEROFROOMS = table.Column<int>(type: "int", nullable: false),
                    CONTENTFROM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CONTENTTYPE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATEDDATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ISACTIVE = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contents", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Contents_ContentCategories_CATEGORYID",
                        column: x => x.CATEGORYID,
                        principalTable: "ContentCategories",
                        principalColumn: "CATEGORYID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContentAnswers",
                columns: table => new
                {
                    ANSWERID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CONTENTID = table.Column<int>(type: "int", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    USERID = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentAnswers", x => x.ANSWERID);
                    table.ForeignKey(
                        name: "FK_ContentAnswers_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContentAnswers_Contents_CONTENTID",
                        column: x => x.CONTENTID,
                        principalTable: "Contents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContentInteractions",
                columns: table => new
                {
                    INTERACTIONID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CONTENTID = table.Column<int>(type: "int", nullable: false),
                    VIEWCOUNT = table.Column<int>(type: "int", nullable: false),
                    FAVORITECOUNT = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentInteractions", x => x.INTERACTIONID);
                    table.ForeignKey(
                        name: "FK_ContentInteractions_Contents_CONTENTID",
                        column: x => x.CONTENTID,
                        principalTable: "Contents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContentQuestions",
                columns: table => new
                {
                    QUESTIONID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CONTENTID = table.Column<int>(type: "int", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    USERID = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentQuestions", x => x.QUESTIONID);
                    table.ForeignKey(
                        name: "FK_ContentQuestions_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContentQuestions_Contents_CONTENTID",
                        column: x => x.CONTENTID,
                        principalTable: "Contents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContentTagMaps",
                columns: table => new
                {
                    MAPID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CONTENTID = table.Column<int>(type: "int", nullable: false),
                    TAGID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentTagMaps", x => x.MAPID);
                    table.ForeignKey(
                        name: "FK_ContentTagMaps_Contents_CONTENTID",
                        column: x => x.CONTENTID,
                        principalTable: "Contents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContentTagMaps_Tags_TAGID",
                        column: x => x.TAGID,
                        principalTable: "Tags",
                        principalColumn: "TAGID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FirmDocs",
                columns: table => new
                {
                    IMGID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IMGDATA = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    CONTENTID = table.Column<int>(type: "int", nullable: false),
                    ID = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FirmDocs", x => x.IMGID);
                    table.ForeignKey(
                        name: "FK_FirmDocs_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FirmDocs_Contents_CONTENTID",
                        column: x => x.CONTENTID,
                        principalTable: "Contents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ContentAnswers_AppUserId",
                table: "ContentAnswers",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentAnswers_CONTENTID",
                table: "ContentAnswers",
                column: "CONTENTID");

            migrationBuilder.CreateIndex(
                name: "IX_ContentInteractions_CONTENTID",
                table: "ContentInteractions",
                column: "CONTENTID");

            migrationBuilder.CreateIndex(
                name: "IX_ContentQuestions_AppUserId",
                table: "ContentQuestions",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentQuestions_CONTENTID",
                table: "ContentQuestions",
                column: "CONTENTID");

            migrationBuilder.CreateIndex(
                name: "IX_Contents_CATEGORYID",
                table: "Contents",
                column: "CATEGORYID");

            migrationBuilder.CreateIndex(
                name: "IX_ContentTagMaps_CONTENTID",
                table: "ContentTagMaps",
                column: "CONTENTID");

            migrationBuilder.CreateIndex(
                name: "IX_ContentTagMaps_TAGID",
                table: "ContentTagMaps",
                column: "TAGID");

            migrationBuilder.CreateIndex(
                name: "IX_FirmDocs_AppUserId",
                table: "FirmDocs",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FirmDocs_CONTENTID",
                table: "FirmDocs",
                column: "CONTENTID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ContentAnswers");

            migrationBuilder.DropTable(
                name: "ContentInteractions");

            migrationBuilder.DropTable(
                name: "ContentQuestions");

            migrationBuilder.DropTable(
                name: "ContentTagMaps");

            migrationBuilder.DropTable(
                name: "FirmDocs");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Contents");

            migrationBuilder.DropTable(
                name: "ContentCategories");
        }
    }
}
