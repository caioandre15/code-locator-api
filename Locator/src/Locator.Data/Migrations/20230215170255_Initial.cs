using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Locator.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    Brand = table.Column<string>(type: "varchar(20)", nullable: false),
                    YearOfManufacture = table.Column<string>(type: "varchar(10)", nullable: false),
                    Version = table.Column<string>(type: "varchar(100)", nullable: false),
                    Plate = table.Column<string>(type: "varchar(10)", nullable: false),
                    TypeOfUse = table.Column<string>(type: "varchar(20)", nullable: false),
                    Group = table.Column<string>(type: "varchar(20)", nullable: false),
                    Description = table.Column<string>(type: "varchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Characteristics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Model = table.Column<string>(type: "varchar(20)", nullable: false),
                    Motorization = table.Column<string>(type: "varchar(20)", nullable: false),
                    Color = table.Column<string>(type: "varchar(20)", nullable: false),
                    TransportLoadCapacity = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characteristics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characteristics_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Optionals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ElectricWindow = table.Column<bool>(type: "bool", nullable: false),
                    EletricLock = table.Column<bool>(type: "bool", nullable: false),
                    HydraulicSteering = table.Column<bool>(type: "bool", nullable: false),
                    AirBag = table.Column<bool>(type: "bool", nullable: false),
                    Abs = table.Column<bool>(type: "bool", nullable: false),
                    AutomaticTransmission = table.Column<bool>(type: "bool", nullable: false),
                    AirConditioning = table.Column<bool>(type: "bool", nullable: false),
                    QuantitiesOfDoorserty = table.Column<int>(type: "int", nullable: false),
                    QuantitiesOfPeople = table.Column<int>(type: "int", nullable: false),
                    QuantitiesOfBags = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Optionals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Optionals_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characteristics_CarId",
                table: "Characteristics",
                column: "CarId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Optionals_CarId",
                table: "Optionals",
                column: "CarId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Characteristics");

            migrationBuilder.DropTable(
                name: "Optionals");

            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
