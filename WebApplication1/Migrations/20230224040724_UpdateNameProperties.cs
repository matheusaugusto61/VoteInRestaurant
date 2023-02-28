using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VoteInRestaurant.Migrations
{
    public partial class UpdateNameProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votos_restaurant_RestaurantID",
                table: "Votos");

            migrationBuilder.RenameColumn(
                name: "RestaurantID",
                table: "Votos",
                newName: "RestauranteID");

            migrationBuilder.RenameIndex(
                name: "IX_Votos_RestaurantID",
                table: "Votos",
                newName: "IX_Votos_RestauranteID");

            migrationBuilder.AddForeignKey(
                name: "FK_Votos_restaurant_RestauranteID",
                table: "Votos",
                column: "RestauranteID",
                principalTable: "restaurant",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votos_restaurant_RestauranteID",
                table: "Votos");

            migrationBuilder.RenameColumn(
                name: "RestauranteID",
                table: "Votos",
                newName: "RestaurantID");

            migrationBuilder.RenameIndex(
                name: "IX_Votos_RestauranteID",
                table: "Votos",
                newName: "IX_Votos_RestaurantID");

            migrationBuilder.AddForeignKey(
                name: "FK_Votos_restaurant_RestaurantID",
                table: "Votos",
                column: "RestaurantID",
                principalTable: "restaurant",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
