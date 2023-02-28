using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VoteInRestaurant.Migrations
{
    public partial class UpdateEntityVoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomePessoa",
                table: "Votos");

            migrationBuilder.AddColumn<long>(
                name: "IdPessoa",
                table: "Votos",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdPessoa",
                table: "Votos");

            migrationBuilder.AddColumn<string>(
                name: "NomePessoa",
                table: "Votos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
