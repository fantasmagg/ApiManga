using Microsoft.EntityFrameworkCore;

namespace practicaWebApiManga.Entidad.Seeding
{
    public class SeedingModuloConsulta
    {

        public static void Seed(ModelBuilder modelBuilder)
        {
            var acción = new Genero { GeneroId = 1, Nombre = "Acción" };
            var animación = new Genero { GeneroId = 2, Nombre = "Animación" };
            var comedia = new Genero { GeneroId = 3, Nombre = "Comedia" };
            var cienciaFicción = new Genero { GeneroId = 4, Nombre = "Ciencia ficción" };
            var drama = new Genero { GeneroId = 5, Nombre = "Drama" };
            var hentai = new Genero { GeneroId = 6, Nombre = "Hentai" };
            var ecchi = new Genero { GeneroId = 7, Nombre = "Ecchi" };
            modelBuilder.Entity<Genero>().HasData(acción, animación, comedia, cienciaFicción, drama,hentai,ecchi);
        }

    }
}
