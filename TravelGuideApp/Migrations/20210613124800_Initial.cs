using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelGuideApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    address = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    country = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transport",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transport", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hotel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    nbEtoile = table.Column<int>(nullable: false),
                    IdAddress = table.Column<int>(nullable: false),
                    AddressId = table.Column<int>(nullable: true),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hotel_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TouristicSite",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    YearsOfSeniority = table.Column<int>(nullable: false),
                    IdAddress = table.Column<int>(nullable: false),
                    AddressId = table.Column<int>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TouristicSite", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TouristicSite_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Num = table.Column<int>(nullable: false),
                    TypeRoom = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    HotelID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Room_Hotel_HotelID",
                        column: x => x.HotelID,
                        principalTable: "Hotel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Activity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    genre = table.Column<string>(nullable: true),
                    prix = table.Column<double>(nullable: false),
                    TouristicSiteID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activity_TouristicSite_TouristicSiteID",
                        column: x => x.TouristicSiteID,
                        principalTable: "TouristicSite",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bus",
                columns: table => new
                {
                    NumLine = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HotelID = table.Column<int>(nullable: false),
                    TouristicSiteID = table.Column<int>(nullable: false),
                    TransportID = table.Column<int>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    Schedule = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bus", x => x.NumLine);
                    table.ForeignKey(
                        name: "FK_Bus_Hotel_HotelID",
                        column: x => x.HotelID,
                        principalTable: "Hotel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bus_TouristicSite_TouristicSiteID",
                        column: x => x.TouristicSiteID,
                        principalTable: "TouristicSite",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bus_Transport_TransportID",
                        column: x => x.TransportID,
                        principalTable: "Transport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Restaurant",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    InHotel = table.Column<bool>(nullable: false),
                    cuisineType = table.Column<int>(nullable: false),
                    Telephone = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    IdAddress = table.Column<int>(nullable: false),
                    AddressId = table.Column<int>(nullable: true),
                    IdHotel = table.Column<int>(nullable: true),
                    HotelId = table.Column<int>(nullable: true),
                    IdTouristicSite = table.Column<int>(nullable: true),
                    TouristicSiteId = table.Column<int>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Restaurant_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Restaurant_Hotel_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Restaurant_TouristicSite_TouristicSiteId",
                        column: x => x.TouristicSiteId,
                        principalTable: "TouristicSite",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    review = table.Column<int>(nullable: false),
                    feedback = table.Column<string>(nullable: true),
                    HotelId = table.Column<int>(nullable: true),
                    RestaurantId = table.Column<int>(nullable: true),
                    touristicSiteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Review_Hotel_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Review_Restaurant_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Review_TouristicSite_touristicSiteId",
                        column: x => x.touristicSiteId,
                        principalTable: "TouristicSite",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activity_TouristicSiteID",
                table: "Activity",
                column: "TouristicSiteID");

            migrationBuilder.CreateIndex(
                name: "IX_Bus_HotelID",
                table: "Bus",
                column: "HotelID");

            migrationBuilder.CreateIndex(
                name: "IX_Bus_TouristicSiteID",
                table: "Bus",
                column: "TouristicSiteID");

            migrationBuilder.CreateIndex(
                name: "IX_Bus_TransportID",
                table: "Bus",
                column: "TransportID");

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_AddressId",
                table: "Hotel",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_AddressId",
                table: "Restaurant",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_HotelId",
                table: "Restaurant",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_TouristicSiteId",
                table: "Restaurant",
                column: "TouristicSiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_HotelId",
                table: "Review",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_RestaurantId",
                table: "Review",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_touristicSiteId",
                table: "Review",
                column: "touristicSiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_HotelID",
                table: "Room",
                column: "HotelID");

            migrationBuilder.CreateIndex(
                name: "IX_TouristicSite_AddressId",
                table: "TouristicSite",
                column: "AddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activity");

            migrationBuilder.DropTable(
                name: "Bus");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "Transport");

            migrationBuilder.DropTable(
                name: "Restaurant");

            migrationBuilder.DropTable(
                name: "Hotel");

            migrationBuilder.DropTable(
                name: "TouristicSite");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
