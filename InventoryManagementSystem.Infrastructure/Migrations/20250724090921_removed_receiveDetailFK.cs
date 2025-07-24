using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class removed_receiveDetailFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceiveDetails_OrderDetails_OrderDetailsOrderDetailId",
                table: "ReceiveDetails");

            migrationBuilder.DropIndex(
                name: "IX_ReceiveDetails_OrderDetailsOrderDetailId",
                table: "ReceiveDetails");

            migrationBuilder.DropColumn(
                name: "OrderDetailsOrderDetailId",
                table: "ReceiveDetails");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiveDetails_OrderDetailId",
                table: "ReceiveDetails",
                column: "OrderDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiveDetails_OrderDetails_OrderDetailId",
                table: "ReceiveDetails",
                column: "OrderDetailId",
                principalTable: "OrderDetails",
                principalColumn: "OrderDetailId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceiveDetails_OrderDetails_OrderDetailId",
                table: "ReceiveDetails");

            migrationBuilder.DropIndex(
                name: "IX_ReceiveDetails_OrderDetailId",
                table: "ReceiveDetails");

            migrationBuilder.AddColumn<int>(
                name: "OrderDetailsOrderDetailId",
                table: "ReceiveDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ReceiveDetails_OrderDetailsOrderDetailId",
                table: "ReceiveDetails",
                column: "OrderDetailsOrderDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiveDetails_OrderDetails_OrderDetailsOrderDetailId",
                table: "ReceiveDetails",
                column: "OrderDetailsOrderDetailId",
                principalTable: "OrderDetails",
                principalColumn: "OrderDetailId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
