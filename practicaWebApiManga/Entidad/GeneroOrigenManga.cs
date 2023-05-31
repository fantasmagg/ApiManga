namespace practicaWebApiManga.Entidad
{
    public class GeneroOrigenManga
    {
        public int GeneroId { get; set; }
        public int OrigenDelMangaId { get; set; }
        public string OrigenManga { get; set; }
        public int Orden { get; set; }
        public Genero Genero { get; set; }
        public OrigenDelManga OrigenDelManga { get; set; }
    }
}
