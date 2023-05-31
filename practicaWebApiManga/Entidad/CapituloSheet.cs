using System.ComponentModel.DataAnnotations;

namespace practicaWebApiManga.Entidad
{
    public class CapituloSheet
    {
        public int CapituloSheetId { get; set; }
        public int CapituloMangasId { get; set; }
        [Required(ErrorMessage = "Este {0} es necesario")]
        public int OrdenDeSheet { get; set; }
        [Required(ErrorMessage ="Este {0} es necesario")]
        [Url]
        public string urlSheetM { get; set; }
        public CapituloMangas CapituloMangas { get; set; }
    }
}
