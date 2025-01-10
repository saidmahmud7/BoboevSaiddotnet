using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Resturants_ResturantId",
                table: "Menus");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Resturants_ResturantId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ResturantId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Menus_ResturantId",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "ResturantId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ResturantId",
                table: "Menus");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_RestaurantId",
                table: "Orders",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_RestaurantId",
                table: "Menus",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Resturants_RestaurantId",
                table: "Menus",
                column: "RestaurantId",
                principalTable: "Resturants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Resturants_RestaurantId",
                table: "Orders",
                column: "RestaurantId",
                principalTable: "Resturants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Resturants_RestaurantId",
                table: "Menus");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Resturants_RestaurantId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_RestaurantId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Menus_RestaurantId",
                table: "Menus");

            migrationBuilder.AddColumn<int>(
                name: "ResturantId",
                table: "Orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ResturantId",
                table: "Menus",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ResturantId",
                table: "Orders",
                column: "ResturantId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_ResturantId",
                table: "Menus",
                column: "ResturantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Resturants_ResturantId",
                table: "Menus",
                column: "ResturantId",
                principalTable: "Resturants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Resturants_ResturantId",
                table: "Orders",
                column: "ResturantId",
                principalTable: "Resturants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
