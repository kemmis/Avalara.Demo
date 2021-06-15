using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Counties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Counties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CountyTaxRates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountyId = table.Column<int>(type: "int", nullable: true),
                    GeneralIntrastateRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GeneralInterstateRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FoodDrugIntrastateRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FoodDrugInterstateRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BeginDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountyTaxRates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CountyTaxRates_Counties_CountyId",
                        column: x => x.CountyId,
                        principalTable: "Counties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StateTaxRates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateId = table.Column<int>(type: "int", nullable: true),
                    GeneralIntrastateRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GeneralInterstateRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FoodDrugIntrastateRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FoodDrugInterstateRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BeginDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateTaxRates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StateTaxRates_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CountyTaxRates_CountyId",
                table: "CountyTaxRates",
                column: "CountyId");

            migrationBuilder.CreateIndex(
                name: "IX_StateTaxRates_StateId",
                table: "StateTaxRates",
                column: "StateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountyTaxRates");

            migrationBuilder.DropTable(
                name: "StateTaxRates");

            migrationBuilder.DropTable(
                name: "Counties");

            migrationBuilder.DropTable(
                name: "States");
        }
    }
}
