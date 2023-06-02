using practicaWebApiManga.Entidad;
using System.ComponentModel.DataAnnotations;

namespace practicaWebApiManga.DTOs
{
    public class OrigenDelMangaCreacionDTO
    {
        public int OrigenDelMangaId { get; set; }
        [Required(ErrorMessage = "Este {0} campo es requerido")]
        public string titulo { get; set; }
        public string descripcion { get; set; }
        [Required(ErrorMessage = "Este {0} campo es requerido")]
      

        public HashSet<Genero> Genero { get; set; }

        
    }
}
