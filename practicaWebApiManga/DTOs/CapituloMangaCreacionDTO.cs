using System.ComponentModel.DataAnnotations;

namespace practicaWebApiManga.DTOs
{
    public class CapituloMangaCreacionDTO
    {
        [Required(ErrorMessage = "Este {0} campo es requerido")]
        public int OrigenDelMangaid { get; set; }
        [Required(ErrorMessage = "Este {0} campo es requerido")]
        public int NumeroCap { get; set; }
        public List<string> UrlCap { get; set; }
    }
}
