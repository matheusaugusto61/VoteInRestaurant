using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VoteInRestaurant.Migrations
{
    public partial class AddForeignKeyPessoaID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddForeignKey(
                name: "FK_Votos_Pessoas_IdPessoa",
                table: "Votos",
                column: "IdPessoa",
                principalTable: "Pessoas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votos_Pessoas_IdPessoa",
                table: "Votos");

        }
    }
}
