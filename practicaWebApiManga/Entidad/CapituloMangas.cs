using System.ComponentModel.DataAnnotations;

namespace practicaWebApiManga.Entidad
{
    public class CapituloMangas
    {
        public int CapituloMangasId { get; set; }
        [Required(ErrorMessage = "Este {0} campo es requerido")]
        public int OrigenDelMangaid { get; set; }
        [Required(ErrorMessage = "Este {0} campo es requerido")]
        public int NumeroCap { get; set; }
        public OrigenDelManga OrigenDelManga { get; set; }
        public List<CapituloSheet> capituloSheets { get; set; }
    }
}
