using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace practicaWebApiManga.Migrations
{
    public partial class inicios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "generos",
                columns: table => new
                {
                    GeneroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_generos", x => x.GeneroId);
                });

            migrationBuilder.CreateTable(
                name: "origenDelMangas",
                columns: table => new
                {
                    OrigenDelMangaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_origenDelMangas", x => x.OrigenDelMangaId);
                });

            migrationBuilder.CreateTable(
                name: "capituloMangas",
                columns: table => new
                {
                    CapituloMangasId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrigenDelMangaid = table.Column<int>(type: "int", nullable: false),
                    NumeroCap = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_capituloMangas", x => x.CapituloMangasId);
                    table.ForeignKey(
                        name: "FK_capituloMangas_origenDelMangas_OrigenDelMangaid",
                        column: x => x.OrigenDelMangaid,
                        principalTable: "origenDelMangas",
                        principalColumn: "OrigenDelMangaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "generoOrigenMangas",
                columns: table => new
                {
                    GeneroId = table.Column<int>(type: "int", nullable: false),
                    OrigenDelMangaId = table.Column<int>(type: "int", nullable: false),
                    OrigenManga = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Orden = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_generoOrigenMangas", x => new { x.GeneroId, x.OrigenDelMangaId });
                    table.ForeignKey(
                        name: "FK_generoOrigenMangas_generos_GeneroId",
                        column: x => x.GeneroId,
                        principalTable: "generos",
                        principalColumn: "GeneroId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_generoOrigenMangas_origenDelMangas_OrigenDelMangaId",
                        column: x => x.OrigenDelMangaId,
                        principalTable: "origenDelMangas",
                        principalColumn: "OrigenDelMangaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "imagenPresentacions",
                columns: table => new
                {
                    ImagenPresentacionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImagenPresentacionUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrigenDelMangaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_imagenPresentacions", x => x.ImagenPresentacionId);
                    table.ForeignKey(
                        name: "FK_imagenPresentacions_origenDelMangas_OrigenDelMangaId",
                        column: x => x.OrigenDelMangaId,
                        principalTable: "origenDelMangas",
                        principalColumn: "OrigenDelMangaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "capituloSheets",
                columns: table => new
                {
                    CapituloSheetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CapituloMangasId = table.Column<int>(type: "int", nullable: false),
                    OrdenDeSheet = table.Column<int>(type: "int", nullable: false),
                    urlSheetM = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_capituloSheets", x => new { x.CapituloSheetId, x.CapituloMangasId });
                    table.ForeignKey(
                        name: "FK_capituloSheets_capituloMangas_CapituloMangasId",
                        column: x => x.CapituloMangasId,
                        principalTable: "capituloMangas",
                        principalColumn: "CapituloMangasId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "generos",
                columns: new[] { "GeneroId", "Nombre" },
                values: new object[,]
                {
                    { 1, "Acción" },
                    { 2, "Animación" },
                    { 3, "Comedia" },
                    { 4, "Ciencia ficción" },
                    { 5, "Drama" },
                    { 6, "Hentai" },
                    { 7, "Ecchi" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_capituloMangas_OrigenDelMangaid",
                table: "capituloMangas",
                column: "OrigenDelMangaid");

            migrationBuilder.CreateIndex(
                name: "IX_capituloSheets_CapituloMangasId",
                table: "capituloSheets",
                column: "CapituloMangasId");

            migrationBuilder.CreateIndex(
                name: "IX_generoOrigenMangas_OrigenDelMangaId",
                table: "generoOrigenMangas",
                column: "OrigenDelMangaId");

            migrationBuilder.CreateIndex(
                name: "IX_imagenPresentacions_OrigenDelMangaId",
                table: "imagenPresentacions",
                column: "OrigenDelMangaId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "capituloSheets");

            migrationBuilder.DropTable(
                name: "generoOrigenMangas");

            migrationBuilder.DropTable(
                name: "imagenPresentacions");

            migrationBuilder.DropTable(
                name: "capituloMangas");

            migrationBuilder.DropTable(
                name: "generos");

            migrationBuilder.DropTable(
                name: "origenDelMangas");
        }
    }
}
