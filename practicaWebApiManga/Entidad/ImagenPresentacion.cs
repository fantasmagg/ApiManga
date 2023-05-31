using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace practicaWebApiManga.Entidad
{
    public class ImagenPresentacion
    {
        public int ImagenPresentacionId { get; set; }
        [Required(ErrorMessage = "Este {0} campo es requerido")]
        [Url]
        public string ImagenPresentacionUrl { get; set; }

        public int OrigenDelMangaId { get; set; }
    }
}
