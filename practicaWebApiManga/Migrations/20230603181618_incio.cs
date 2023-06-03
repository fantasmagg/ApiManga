using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace practicaWebApiManga.Migrations
{
    public partial class incio : Migration
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
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    imagenPresentacion = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "GeneroOrigenDelManga",
                columns: table => new
                {
                    GeneroId = table.Column<int>(type: "int", nullable: false),
                    OrigenDelMangaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneroOrigenDelManga", x => new { x.GeneroId, x.OrigenDelMangaId });
                    table.ForeignKey(
                        name: "FK_GeneroOrigenDelManga_generos_GeneroId",
                        column: x => x.GeneroId,
                        principalTable: "generos",
                        principalColumn: "GeneroId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneroOrigenDelManga_origenDelMangas_OrigenDelMangaId",
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
                    { 7, "Ecchi" },
                    { 8, "aventura" },
                    { 9, "fantacia" }
                });

            migrationBuilder.InsertData(
                table: "origenDelMangas",
                columns: new[] { "OrigenDelMangaId", "descripcion", "imagenPresentacion", "titulo" },
                values: new object[,]
                {
                    { 1, "El agente de inteligencia de “HID” y su hermano gemelo Baek Do-gyeong, el jefe de una organización criminal. Hermanos gemelos que vivieron el mismo rostro y vidas diferentes. El hermano menor que fue traicionado por la organización decide abandonar su identidad y convertirse en el hermano mayor. ¡Un agente de inteligencia se convierte en el jefe de una organización criminal…!", "https://dashboard.olympusscans.com/storage/comics/covers/8/8a4ab252a7c88ecca32113dbf5cb546ebb934d9f_s2_n2-xl.webp", "Baek XX" },
                    { 2, "El protagonista de una historia siempre se decide desde el principio. Por mucho que se esfuerce el papel secundario, al final sólo será un papel secundario. Entonces, llegó un momento en que todo eso cambió. [León, ¿crees que estás capacitado?] La espada sagrada que debería elegir al héroe del oráculo se acercara a él. ¿Qué? ¿No tienes talento, eres pobre y no tienes contactos? No te preocupes. ¡El héroe que puede resolver cualquier cosa con la espada sagrada está aquí! ...Hubo un periodo en el que yo también esperaba así. Aquí es donde comienza la historia de León como héroe.", "https://dashboard.olympusscans.com/storage/comics/covers/128/op-xl.webp", "Espada OP" }
                });

            migrationBuilder.InsertData(
                table: "GeneroOrigenDelManga",
                columns: new[] { "GeneroId", "OrigenDelMangaId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 4, 1 },
                    { 8, 2 },
                    { 9, 2 }
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
                name: "IX_GeneroOrigenDelManga_OrigenDelMangaId",
                table: "GeneroOrigenDelManga",
                column: "OrigenDelMangaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "capituloSheets");

            migrationBuilder.DropTable(
                name: "GeneroOrigenDelManga");

            migrationBuilder.DropTable(
                name: "capituloMangas");

            migrationBuilder.DropTable(
                name: "generos");

            migrationBuilder.DropTable(
                name: "origenDelMangas");
        }
    }
}
