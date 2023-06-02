using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace practicaWebApiManga.Entidad
{
    public class OrigenDelManga
    {
        public int OrigenDelMangaId { get; set; }
        [Required(ErrorMessage = "Este {0} campo es requerido")]
        public string titulo { get; set; }
        public string descripcion { get; set; }
       // [Required(ErrorMessage = "Este {0} campo es requerido")]
        public string imagenPresentacion { get; set; }
        
        public HashSet<Genero> Genero { get; set; }
        
        public HashSet<CapituloMangas> CapituloMangas { get; set; }
    }
}
