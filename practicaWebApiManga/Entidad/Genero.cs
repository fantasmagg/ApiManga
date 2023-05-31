using System.ComponentModel.DataAnnotations;

namespace practicaWebApiManga.Entidad
{
    public class Genero
    {
        public int GeneroId { get; set; }
        [Required(ErrorMessage = "Este {0} campo es requerido")]
        public string Nombre { get; set; }

        public HashSet<GeneroOrigenManga> GeneroOrigenMangas { get; set; }
    }
}
