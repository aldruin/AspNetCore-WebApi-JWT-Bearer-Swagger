using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CashFlowAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Caregory",
                table: "FinancialExpenses",
                newName: "Category");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Category",
                table: "FinancialExpenses",
                newName: "Caregory");
        }
    }
}
