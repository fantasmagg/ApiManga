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
            var aventura = new Genero { GeneroId = 8, Nombre = "aventura" };
            var fantacia = new Genero { GeneroId = 9, Nombre = "fantacia" };
            modelBuilder.Entity<Genero>().HasData(acción, animación, comedia, cienciaFicción, drama,hentai,ecchi,aventura,fantacia);

            var avengers = new OrigenDelManga()
            {
               OrigenDelMangaId = 1,
                imagenPresentacion = "https://dashboard.olympusscans.com/storage/comics/covers/8/8a4ab252a7c88ecca32113dbf5cb546ebb934d9f_s2_n2-xl.webp",
                titulo = "Baek XX",
                descripcion = "El agente de inteligencia de “HID” y su hermano gemelo Baek Do-gyeong, el jefe de una organización criminal. Hermanos gemelos que vivieron el mismo rostro y vidas diferentes. El hermano menor que fue traicionado por la organización decide abandonar su identidad y convertirse en el hermano mayor. ¡Un agente de inteligencia se convierte en el jefe de una organización criminal…!"
                

            };
           
    

            var entidadGeneroPelicula = "GeneroOrigenDelManga";
            var generoIdPropiedad = "GeneroId";
            var peliculaIdPropiedad = "OrigenDelMangaId";

            modelBuilder.Entity(entidadGeneroPelicula).HasData(
                new Dictionary<string, object> { [generoIdPropiedad] = acción.GeneroId, [peliculaIdPropiedad] = avengers.OrigenDelMangaId },
                new Dictionary<string, object> { [generoIdPropiedad] = cienciaFicción.GeneroId, [peliculaIdPropiedad] = avengers.OrigenDelMangaId }
            );
            var Espada_OP = new OrigenDelManga()
            {
                OrigenDelMangaId = 2,
                imagenPresentacion = "https://dashboard.olympusscans.com/storage/comics/covers/128/op-xl.webp",
                titulo = "Espada OP",
                descripcion = "El protagonista de una historia siempre se decide desde el principio. Por mucho que se esfuerce el papel secundario, al final sólo será un papel secundario. Entonces, llegó un momento en que todo eso cambió. [León, ¿crees que estás capacitado?] La espada sagrada que debería elegir al héroe del oráculo se acercara a él. ¿Qué? ¿No tienes talento, eres pobre y no tienes contactos? No te preocupes. ¡El héroe que puede resolver cualquier cosa con la espada sagrada está aquí! ...Hubo un periodo en el que yo también esperaba así. Aquí es donde comienza la historia de León como héroe."


            };
            modelBuilder.Entity(entidadGeneroPelicula).HasData(
               new Dictionary<string, object> { [generoIdPropiedad] = aventura.GeneroId, [peliculaIdPropiedad] = Espada_OP.OrigenDelMangaId },
               new Dictionary<string, object> { [generoIdPropiedad] = fantacia.GeneroId, [peliculaIdPropiedad] = Espada_OP.OrigenDelMangaId },
               new Dictionary<string, object> { [generoIdPropiedad] = acción.GeneroId, [peliculaIdPropiedad] = Espada_OP.OrigenDelMangaId }
           );

            modelBuilder.Entity<OrigenDelManga>().HasData(avengers,Espada_OP);

        }

    }
}
