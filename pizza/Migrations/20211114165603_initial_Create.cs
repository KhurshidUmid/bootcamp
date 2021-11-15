using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace pizza.Migrations
{
    public partial class initial_Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pizzas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ingradients = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    Price = table.Column<double>(type: "float", maxLength: 1000, nullable: false),
                    StockStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pizzas");
        }
    }
}
