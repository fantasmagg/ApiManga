using System.ComponentModel.DataAnnotations;

namespace practicaWebApiManga.Entidad
{
    public class OrigenDelManga
    {
        public int OrigenDelMangaId { get; set; }
        [Required(ErrorMessage = "Este {0} campo es requerido")]
        public string titulo { get; set; }
        public string descripcion { get; set; }
        [Required(ErrorMessage = "Este {0} campo es requerido")]
        public ImagenPresentacion imagenPresentacion { get; set; }
        public HashSet<GeneroOrigenManga> GeneroOrigenMangas { get; set; }
        public HashSet<CapituloMangas> CapituloMangas { get; set; }
    }
}
