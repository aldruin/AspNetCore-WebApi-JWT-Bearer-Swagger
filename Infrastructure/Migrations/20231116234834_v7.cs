using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CashFlowAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Caregory",
                table: "FinancialEntries",
                newName: "Category");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Category",
                table: "FinancialEntries",
                newName: "Caregory");
        }
    }
}
