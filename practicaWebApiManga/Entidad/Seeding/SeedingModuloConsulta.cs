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

            var avengers = new OrigenDelManga()
            {
               OrigenDelMangaId = 1,
                imagenPresentacion = "https://dashboard.olympusscans.com/storage/comics/covers/8/8a4ab252a7c88ecca32113dbf5cb546ebb934d9f_s2_n2-xl.webp",
                titulo = "Baek XX",
                descripcion = "El agente de inteligencia de “HID” y su hermano gemelo Baek Do-gyeong, el jefe de una organización criminal. Hermanos gemelos que vivieron el mismo rostro y vidas diferentes. El hermano menor que fue traicionado por la organización decide abandonar su identidad y convertirse en el hermano mayor. ¡Un agente de inteligencia se convierte en el jefe de una organización criminal…!"
                

            };
            modelBuilder.Entity<OrigenDelManga>().HasData(avengers);

            var entidadGeneroPelicula = "GeneroOrigenDelManga";
            var generoIdPropiedad = "GeneroId";
            var peliculaIdPropiedad = "OrigenDelMangaId";

            modelBuilder.Entity(entidadGeneroPelicula).HasData(
                new Dictionary<string, object> { [generoIdPropiedad] = acción.GeneroId, [peliculaIdPropiedad] = avengers.OrigenDelMangaId },
                new Dictionary<string, object> { [generoIdPropiedad] = cienciaFicción.GeneroId, [peliculaIdPropiedad] = avengers.OrigenDelMangaId }
            );

        }

    }
}
