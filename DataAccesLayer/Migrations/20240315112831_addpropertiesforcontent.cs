using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccesLayer.Migrations
{
    /// <inheritdoc />
    public partial class addpropertiesforcontent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AgeOfBuilding",
                table: "Contents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Balcony",
                table: "Contents",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Dues",
                table: "Contents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Elevator",
                table: "Contents",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Exchangeable",
                table: "Contents",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "FloorNumber",
                table: "Contents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Heating",
                table: "Contents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfBathrooms",
                table: "Contents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfFloors",
                table: "Contents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ParkingArea",
                table: "Contents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ContentExternalProperties",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    ContentID = table.Column<int>(type: "int", nullable: false),
                    ChargingStation = table.Column<bool>(type: "bit", nullable: false),
                    Security = table.Column<bool>(type: "bit", nullable: false),
                    CableTV = table.Column<bool>(type: "bit", nullable: false),
                    Playground = table.Column<bool>(type: "bit", nullable: false),
                    OutdoorPool = table.Column<bool>(type: "bit", nullable: false),
                    IndoorPool = table.Column<bool>(type: "bit", nullable: false),
                    WaterTank = table.Column<bool>(type: "bit", nullable: false),
                    Satellite = table.Column<bool>(type: "bit", nullable: false),
                    Preschool = table.Column<bool>(type: "bit", nullable: false),
                    ThermalInsulation = table.Column<bool>(type: "bit", nullable: false),
                    CameraSystem = table.Column<bool>(type: "bit", nullable: false),
                    TennisCourt = table.Column<bool>(type: "bit", nullable: false),
                    Sauna = table.Column<bool>(type: "bit", nullable: false),
                    Gym = table.Column<bool>(type: "bit", nullable: false),
                    TurkishBath = table.Column<bool>(type: "bit", nullable: false),
                    FireEscape = table.Column<bool>(type: "bit", nullable: false),
                    BuildingAttendant = table.Column<bool>(type: "bit", nullable: false)
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
                    ContentID = table.Column<int>(type: "int", nullable: false),
                    ADSL = table.Column<bool>(type: "bit", nullable: false),
                    Alarm = table.Column<bool>(type: "bit", nullable: false),
                    AmericanDoor = table.Column<bool>(type: "bit", nullable: false),
                    DressingRoom = table.Column<bool>(type: "bit", nullable: false),
                    FiberInternet = table.Column<bool>(type: "bit", nullable: false),
                    WaterHeater = table.Column<bool>(type: "bit", nullable: false),
                    Terrace = table.Column<bool>(type: "bit", nullable: false),
                    Fireplace = table.Column<bool>(type: "bit", nullable: false),
                    WiFi = table.Column<bool>(type: "bit", nullable: false),
                    ParquetFloor = table.Column<bool>(type: "bit", nullable: false),
                    Jacuzzi = table.Column<bool>(type: "bit", nullable: false),
                    ShowerCabin = table.Column<bool>(type: "bit", nullable: false),
                    Refrigerator = table.Column<bool>(type: "bit", nullable: false),
                    Wallpaper = table.Column<bool>(type: "bit", nullable: false),
                    EnsuiteBathroom = table.Column<bool>(type: "bit", nullable: false),
                    Barbecue = table.Column<bool>(type: "bit", nullable: false),
                    SmartHome = table.Column<bool>(type: "bit", nullable: false),
                    InsulatedGlass = table.Column<bool>(type: "bit", nullable: false),
                    Dishwasher = table.Column<bool>(type: "bit", nullable: false),
                    WashingMachine = table.Column<bool>(type: "bit", nullable: false),
                    Bathtub = table.Column<bool>(type: "bit", nullable: false),
                    WalkInCloset = table.Column<bool>(type: "bit", nullable: false),
                    Oven = table.Column<bool>(type: "bit", nullable: false),
                    LaundryRoom = table.Column<bool>(type: "bit", nullable: false),
                    Pantry = table.Column<bool>(type: "bit", nullable: false),
                    IntercomSystem = table.Column<bool>(type: "bit", nullable: false),
                    SpotLighting = table.Column<bool>(type: "bit", nullable: false),
                    FaceRecognitionSystem = table.Column<bool>(type: "bit", nullable: false)
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContentExternalProperties");

            migrationBuilder.DropTable(
                name: "ContentInteriorProperties");

            migrationBuilder.DropColumn(
                name: "AgeOfBuilding",
                table: "Contents");

            migrationBuilder.DropColumn(
                name: "Balcony",
                table: "Contents");

            migrationBuilder.DropColumn(
                name: "Dues",
                table: "Contents");

            migrationBuilder.DropColumn(
                name: "Elevator",
                table: "Contents");

            migrationBuilder.DropColumn(
                name: "Exchangeable",
                table: "Contents");

            migrationBuilder.DropColumn(
                name: "FloorNumber",
                table: "Contents");

            migrationBuilder.DropColumn(
                name: "Heating",
                table: "Contents");

            migrationBuilder.DropColumn(
                name: "NumberOfBathrooms",
                table: "Contents");

            migrationBuilder.DropColumn(
                name: "NumberOfFloors",
                table: "Contents");

            migrationBuilder.DropColumn(
                name: "ParkingArea",
                table: "Contents");
        }
    }
}
