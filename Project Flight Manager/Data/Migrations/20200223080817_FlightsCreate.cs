using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Project_Flight_Manager.Models;

namespace Project_Flight_Manager.Data.Migrations
{
    public partial class FlightsCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AirlineID = table.Column<int>(nullable: false),
                    AirlineName = table.Column<string>(nullable: false),
                    FromLocation = table.Column<string>(nullable: false),
                    ToLocation = table.Column<string>(nullable: false),
                    DepatureTime = table.Column<DateTime>(nullable: false),
                    ArrivalTime = table.Column<DateTime>(nullable: false),
                    PilotName = table.Column<string>(nullable: false),
                    Capacity = table.Column<int>(nullable: false),
                    BusinessCapacity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    FirstName = table.Column<string>(nullable: false),
                    MiddleName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    EGN = table.Column<int>(nullable: false),
                    TelNumber = table.Column<int>(nullable: false),
                    Nationality = table.Column<string>(nullable: false),
                    TicketType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.FirstName);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Reservations");
        }
        //protected override void Seed(Project_Flight_Manager.Models.FlightDataModel context)
        //{
            
        //}
    }
}
