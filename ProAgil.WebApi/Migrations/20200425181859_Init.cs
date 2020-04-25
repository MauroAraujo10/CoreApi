using Microsoft.EntityFrameworkCore.Migrations;

namespace ProAgil.WebApi.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Local = table.Column<string>(nullable: true),
                    Data = table.Column<string>(nullable: true),
                    Tema = table.Column<string>(nullable: true),
                    QuantidadePessoas = table.Column<int>(nullable: false),
                    Lote = table.Column<string>(nullable: true),
                    Valor = table.Column<decimal>(nullable: false),
                    ImagemURL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Eventos");
        }
    }
}
