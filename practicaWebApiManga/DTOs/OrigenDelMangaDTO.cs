using practicaWebApiManga.Entidad;

namespace practicaWebApiManga.DTOs
{
    public class OrigenDelMangaDTO
    {
        public string imagenPresentacion { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public HashSet<GeneroDTO> Genero { get; set; }
        public HashSet<CapituloMangasDTO> CapituloMangas { get; set; }
    }
}
