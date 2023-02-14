using Microsoft.EntityFrameworkCore.Migrations;

namespace TallerMecanico.API.Migrations
{
    public partial class AnadirTablaProcedimientoIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Procedimientos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procedimientos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Procedimientos_Descripcion",
                table: "Procedimientos",
                column: "Descripcion",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Procedimientos");
        }
    }
}
