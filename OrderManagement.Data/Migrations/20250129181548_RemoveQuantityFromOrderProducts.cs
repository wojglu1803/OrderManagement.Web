using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveQuantityFromOrderProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "OrderProducts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "OrderProducts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 1);
        }
    }
}
