using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccesLayer.Migrations
{
    /// <inheritdoc />
    public partial class removesometable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContentExternalProperties");

            migrationBuilder.DropTable(
                name: "ContentInteriorProperties");

            migrationBuilder.DropTable(
                name: "ContentTagMaps");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.AlterColumn<string>(
                name: "Town",
                table: "Contents",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Contents",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Contents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ParkingArea",
                table: "Contents",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "NumberOfRooms",
                table: "Contents",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "NumberOfFloors",
                table: "Contents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "NumberOfBathrooms",
                table: "Contents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "NetSquareMeters",
                table: "Contents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Heating",
                table: "Contents",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "GrossSquareMeters",
                table: "Contents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FloorNumber",
                table: "Contents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<bool>(
                name: "Exchangeable",
                table: "Contents",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "Elevator",
                table: "Contents",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<int>(
                name: "Dues",
                table: "Contents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Contents",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Contents",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Contents",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ContentType",
                table: "Contents",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ContentFrom",
                table: "Contents",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Contents",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "Balcony",
                table: "Contents",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<int>(
                name: "AgeOfBuilding",
                table: "Contents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Adress",
                table: "Contents",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Town",
                table: "Contents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Contents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Contents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ParkingArea",
                table: "Contents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NumberOfRooms",
                table: "Contents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NumberOfFloors",
                table: "Contents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NumberOfBathrooms",
                table: "Contents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NetSquareMeters",
                table: "Contents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Heating",
                table: "Contents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GrossSquareMeters",
                table: "Contents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FloorNumber",
                table: "Contents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Exchangeable",
                table: "Contents",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Elevator",
                table: "Contents",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Dues",
                table: "Contents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Contents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Contents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Contents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ContentType",
                table: "Contents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ContentFrom",
                table: "Contents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Contents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Balcony",
                table: "Contents",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AgeOfBuilding",
                table: "Contents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Adress",
                table: "Contents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ContentExternalProperties",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    BuildingAttendant = table.Column<bool>(type: "bit", nullable: false),
                    CableTV = table.Column<bool>(type: "bit", nullable: false),
                    CameraSystem = table.Column<bool>(type: "bit", nullable: false),
                    ChargingStation = table.Column<bool>(type: "bit", nullable: false),
                    ContentID = table.Column<int>(type: "int", nullable: false),
                    FireEscape = table.Column<bool>(type: "bit", nullable: false),
                    Gym = table.Column<bool>(type: "bit", nullable: false),
                    IndoorPool = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    OutdoorPool = table.Column<bool>(type: "bit", nullable: false),
                    Playground = table.Column<bool>(type: "bit", nullable: false),
                    Preschool = table.Column<bool>(type: "bit", nullable: false),
                    Satellite = table.Column<bool>(type: "bit", nullable: false),
                    Sauna = table.Column<bool>(type: "bit", nullable: false),
                    Security = table.Column<bool>(type: "bit", nullable: false),
                    TennisCourt = table.Column<bool>(type: "bit", nullable: false),
                    ThermalInsulation = table.Column<bool>(type: "bit", nullable: false),
                    TurkishBath = table.Column<bool>(type: "bit", nullable: false),
                    WaterTank = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentExternalProperties", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ContentExternalProperties_Contents_ID",
                        column: x => x.ID,
                        principalTable: "Contents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContentInteriorProperties",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    ADSL = table.Column<bool>(type: "bit", nullable: false),
                    Alarm = table.Column<bool>(type: "bit", nullable: false),
                    AmericanDoor = table.Column<bool>(type: "bit", nullable: false),
                    Barbecue = table.Column<bool>(type: "bit", nullable: false),
                    Bathtub = table.Column<bool>(type: "bit", nullable: false),
                    ContentID = table.Column<int>(type: "int", nullable: false),
                    Dishwasher = table.Column<bool>(type: "bit", nullable: false),
                    DressingRoom = table.Column<bool>(type: "bit", nullable: false),
                    EnsuiteBathroom = table.Column<bool>(type: "bit", nullable: false),
                    FaceRecognitionSystem = table.Column<bool>(type: "bit", nullable: false),
                    FiberInternet = table.Column<bool>(type: "bit", nullable: false),
                    Fireplace = table.Column<bool>(type: "bit", nullable: false),
                    InsulatedGlass = table.Column<bool>(type: "bit", nullable: false),
                    IntercomSystem = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Jacuzzi = table.Column<bool>(type: "bit", nullable: false),
                    LaundryRoom = table.Column<bool>(type: "bit", nullable: false),
                    Oven = table.Column<bool>(type: "bit", nullable: false),
                    Pantry = table.Column<bool>(type: "bit", nullable: false),
                    ParquetFloor = table.Column<bool>(type: "bit", nullable: false),
                    Refrigerator = table.Column<bool>(type: "bit", nullable: false),
                    ShowerCabin = table.Column<bool>(type: "bit", nullable: false),
                    SmartHome = table.Column<bool>(type: "bit", nullable: false),
                    SpotLighting = table.Column<bool>(type: "bit", nullable: false),
                    Terrace = table.Column<bool>(type: "bit", nullable: false),
                    WalkInCloset = table.Column<bool>(type: "bit", nullable: false),
                    Wallpaper = table.Column<bool>(type: "bit", nullable: false),
                    WashingMachine = table.Column<bool>(type: "bit", nullable: false),
                    WaterHeater = table.Column<bool>(type: "bit", nullable: false),
                    WiFi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentInteriorProperties", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ContentInteriorProperties_Contents_ID",
                        column: x => x.ID,
                        principalTable: "Contents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    TAGID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ISACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    TAGNAME = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.TAGID);
                });

            migrationBuilder.CreateTable(
                name: "ContentTagMaps",
                columns: table => new
                {
                    MapId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContentID = table.Column<int>(type: "int", nullable: false),
                    TagID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentTagMaps", x => x.MapId);
                    table.ForeignKey(
                        name: "FK_ContentTagMaps_Contents_ContentID",
                        column: x => x.ContentID,
                        principalTable: "Contents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContentTagMaps_Tags_TagID",
                        column: x => x.TagID,
                        principalTable: "Tags",
                        principalColumn: "TAGID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContentTagMaps_ContentID",
                table: "ContentTagMaps",
                column: "ContentID");

            migrationBuilder.CreateIndex(
                name: "IX_ContentTagMaps_TagID",
                table: "ContentTagMaps",
                column: "TagID");
        }
    }
}
