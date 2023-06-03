using System.ComponentModel.DataAnnotations;

namespace practicaWebApiManga.DTOs
{
    public class CapituloSheetDTO
    {
      public int CapituloSheetId { get; set; }
        [Required(ErrorMessage = "Este {0} campo es requerido")]
      
        public int OrdenDeSheet { get; set; }
        [Required(ErrorMessage = "Este {0} es necesario")]
        [Url]
        public string urlSheetM { get; set; }
      
    }
}
