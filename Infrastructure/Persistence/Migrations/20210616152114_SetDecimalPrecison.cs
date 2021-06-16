using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class SetDecimalPrecison : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "GeneralIntrastateRate",
                table: "StateTaxRates",
                type: "decimal(4,4)",
                precision: 4,
                scale: 4,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,2)",
                oldPrecision: 6);

            migrationBuilder.AlterColumn<decimal>(
                name: "GeneralInterstateRate",
                table: "StateTaxRates",
                type: "decimal(4,4)",
                precision: 4,
                scale: 4,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,2)",
                oldPrecision: 6);

            migrationBuilder.AlterColumn<decimal>(
                name: "FoodDrugIntrastateRate",
                table: "StateTaxRates",
                type: "decimal(4,4)",
                precision: 4,
                scale: 4,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,2)",
                oldPrecision: 6);

            migrationBuilder.AlterColumn<decimal>(
                name: "FoodDrugInterstateRate",
                table: "StateTaxRates",
                type: "decimal(4,4)",
                precision: 4,
                scale: 4,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,2)",
                oldPrecision: 6);

            migrationBuilder.AlterColumn<decimal>(
                name: "GeneralIntrastateRate",
                table: "CountyTaxRates",
                type: "decimal(4,4)",
                precision: 4,
                scale: 4,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,2)",
                oldPrecision: 6);

            migrationBuilder.AlterColumn<decimal>(
                name: "GeneralInterstateRate",
                table: "CountyTaxRates",
                type: "decimal(4,4)",
                precision: 4,
                scale: 4,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,2)",
                oldPrecision: 6);

            migrationBuilder.AlterColumn<decimal>(
                name: "FoodDrugIntrastateRate",
                table: "CountyTaxRates",
                type: "decimal(4,4)",
                precision: 4,
                scale: 4,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,2)",
                oldPrecision: 6);

            migrationBuilder.AlterColumn<decimal>(
                name: "FoodDrugInterstateRate",
                table: "CountyTaxRates",
                type: "decimal(4,4)",
                precision: 4,
                scale: 4,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,2)",
                oldPrecision: 6);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "GeneralIntrastateRate",
                table: "StateTaxRates",
                type: "decimal(6,2)",
                precision: 6,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(4,4)",
                oldPrecision: 4,
                oldScale: 4);

            migrationBuilder.AlterColumn<decimal>(
                name: "GeneralInterstateRate",
                table: "StateTaxRates",
                type: "decimal(6,2)",
                precision: 6,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(4,4)",
                oldPrecision: 4,
                oldScale: 4);

            migrationBuilder.AlterColumn<decimal>(
                name: "FoodDrugIntrastateRate",
                table: "StateTaxRates",
                type: "decimal(6,2)",
                precision: 6,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(4,4)",
                oldPrecision: 4,
                oldScale: 4);

            migrationBuilder.AlterColumn<decimal>(
                name: "FoodDrugInterstateRate",
                table: "StateTaxRates",
                type: "decimal(6,2)",
                precision: 6,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(4,4)",
                oldPrecision: 4,
                oldScale: 4);

            migrationBuilder.AlterColumn<decimal>(
                name: "GeneralIntrastateRate",
                table: "CountyTaxRates",
                type: "decimal(6,2)",
                precision: 6,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(4,4)",
                oldPrecision: 4,
                oldScale: 4);

            migrationBuilder.AlterColumn<decimal>(
                name: "GeneralInterstateRate",
                table: "CountyTaxRates",
                type: "decimal(6,2)",
                precision: 6,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(4,4)",
                oldPrecision: 4,
                oldScale: 4);

            migrationBuilder.AlterColumn<decimal>(
                name: "FoodDrugIntrastateRate",
                table: "CountyTaxRates",
                type: "decimal(6,2)",
                precision: 6,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(4,4)",
                oldPrecision: 4,
                oldScale: 4);

            migrationBuilder.AlterColumn<decimal>(
                name: "FoodDrugInterstateRate",
                table: "CountyTaxRates",
                type: "decimal(6,2)",
                precision: 6,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(4,4)",
                oldPrecision: 4,
                oldScale: 4);
        }
    }
}
