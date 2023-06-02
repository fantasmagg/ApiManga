using System.ComponentModel.DataAnnotations;

namespace practicaWebApiManga.DTOs
{
    public class GeneroDTO
    {
        public int GeneroId { get; set; }
        [Required(ErrorMessage = "Este {0} campo es requerido")]
        public string Nombre { get; set; }


    }
}
