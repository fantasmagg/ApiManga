using practicaWebApiManga.Entidad;
using System.ComponentModel.DataAnnotations;

namespace practicaWebApiManga.DTOs
{
    public class CapituloMangasDTO
    {
        public int OrigenDelMangaId { get; set; }
        public int CapituloMangasId { get; set; }
      
        [Required(ErrorMessage = "Este {0} campo es requerido")]
        public int NumeroCap { get; set; }

        public List<CapituloSheetDTO> capituloSheets { get; set; }
 
        //public List<CapituloSheet> capituloSheets { get; set; }
    }
}
