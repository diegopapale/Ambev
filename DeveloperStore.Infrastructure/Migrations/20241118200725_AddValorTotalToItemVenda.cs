using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeveloperStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddValorTotalToItemVenda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ValorTotal",
                table: "ItensVenda",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorTotal",
                table: "ItensVenda");
        }
    }
}
