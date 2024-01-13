using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class NewRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ItemID1",
                table: "ItemOrders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemOrders_ItemID1",
                table: "ItemOrders",
                column: "ItemID1");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemOrders_Items_ItemID1",
                table: "ItemOrders",
                column: "ItemID1",
                principalTable: "Items",
                principalColumn: "ItemID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemOrders_Items_ItemID1",
                table: "ItemOrders");

            migrationBuilder.DropIndex(
                name: "IX_ItemOrders_ItemID1",
                table: "ItemOrders");

            migrationBuilder.DropColumn(
                name: "ItemID1",
                table: "ItemOrders");
        }
    }
}
