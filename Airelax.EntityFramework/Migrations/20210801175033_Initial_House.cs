using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Airelax.EntityFramework.Migrations
{
    public partial class Initial_House : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Houses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateState = table.Column<int>(type: "int", nullable: false),
                    CustomerNumber = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifyTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HouseCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    HouseType = table.Column<int>(type: "int", nullable: false),
                    RoomCategory = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HouseCategories_Houses_Id",
                        column: x => x.Id,
                        principalTable: "Houses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HouseDescriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    HouseHighlight = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    SpaceDescription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    GuestPermission = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Others = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseDescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HouseDescriptions_Houses_Id",
                        column: x => x.Id,
                        principalTable: "Houses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HouseLocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Town = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    AddressDetail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LocationDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TrafficDescription = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HouseLocations_Houses_Id",
                        column: x => x.Id,
                        principalTable: "Houses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HouseRules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    AllowChild = table.Column<bool>(type: "bit", nullable: false),
                    AllowBaby = table.Column<bool>(type: "bit", nullable: false),
                    AllowPet = table.Column<bool>(type: "bit", nullable: false),
                    AllowSmoke = table.Column<bool>(type: "bit", nullable: false),
                    AllowParty = table.Column<bool>(type: "bit", nullable: false),
                    Other = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseRules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HouseRules_Houses_Id",
                        column: x => x.Id,
                        principalTable: "Houses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Policies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CanRealTime = table.Column<bool>(type: "bit", nullable: false),
                    CancelPolicy = table.Column<int>(type: "Money", nullable: false),
                    CheckinTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckoutTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CashPledge = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Policies_Houses_Id",
                        column: x => x.Id,
                        principalTable: "Houses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReservationRules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    MinNight = table.Column<int>(type: "int", nullable: false),
                    MaxNight = table.Column<int>(type: "int", nullable: false),
                    LastReservationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrepareTime = table.Column<int>(type: "int", nullable: false),
                    AvailableTime = table.Column<int>(type: "int", nullable: false),
                    RejectDate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationRules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservationRules_Houses_Id",
                        column: x => x.Id,
                        principalTable: "Houses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Spaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HouseId = table.Column<int>(type: "int", nullable: false),
                    SpaceType = table.Column<int>(type: "int", nullable: false),
                    IsShared = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spaces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Spaces_Houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "Houses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BedroomDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BedType = table.Column<int>(type: "int", nullable: false),
                    BedCount = table.Column<int>(type: "int", nullable: false),
                    HasIndependentBath = table.Column<bool>(type: "bit", nullable: false),
                    SpaceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BedroomDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BedroomDetails_Spaces_SpaceId",
                        column: x => x.SpaceId,
                        principalTable: "Spaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpaceId = table.Column<int>(type: "int", nullable: false),
                    HouseId = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<byte[]>(type: "image", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_Houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "Houses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Photos_Spaces_SpaceId",
                        column: x => x.SpaceId,
                        principalTable: "Spaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BedroomDetails_SpaceId",
                table: "BedroomDetails",
                column: "SpaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_HouseId",
                table: "Photos",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_SpaceId",
                table: "Photos",
                column: "SpaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Spaces_HouseId",
                table: "Spaces",
                column: "HouseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BedroomDetails");

            migrationBuilder.DropTable(
                name: "HouseCategories");

            migrationBuilder.DropTable(
                name: "HouseDescriptions");

            migrationBuilder.DropTable(
                name: "HouseLocations");

            migrationBuilder.DropTable(
                name: "HouseRules");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "Policies");

            migrationBuilder.DropTable(
                name: "ReservationRules");

            migrationBuilder.DropTable(
                name: "Spaces");

            migrationBuilder.DropTable(
                name: "Houses");
        }
    }
}
