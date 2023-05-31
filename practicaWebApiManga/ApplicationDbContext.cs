using Microsoft.EntityFrameworkCore;
using practicaWebApiManga.Entidad;
using practicaWebApiManga.Entidad.Seeding;

namespace practicaWebApiManga
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            /* modelBuilder.Entity<ImagenPresentacion>().HasIndex(u => u.ImagenPresentacionUrl).IsUnique();
             modelBuilder.Entity<OrigenDelManga>().HasIndex(t => t.titulo).IsUnique();*/

            // esto es por que esta sera la tabla intermedia de una ralacion de muchos a muchos en tre genero, y origendelmanga
            modelBuilder.Entity<GeneroOrigenManga>().HasKey(prop => new { prop.GeneroId, prop.OrigenDelMangaId });

            modelBuilder.Entity<CapituloSheet>().HasKey(prop => new { prop.CapituloSheetId, prop.CapituloMangasId });

            modelBuilder.Entity<GeneroOrigenManga>().Property(prop => prop.OrigenManga).HasMaxLength(150);

            modelBuilder.Entity<CapituloSheet>()
            .Property(prop => prop.CapituloSheetId)
            .ValueGeneratedOnAdd();

          

            SeedingModuloConsulta.Seed(modelBuilder);
        }

        public DbSet<Genero> generos { get; set; }
        public DbSet<ImagenPresentacion> imagenPresentacions { get; set; }
        public DbSet<OrigenDelManga> origenDelMangas { get; set; }
        public DbSet<CapituloMangas> capituloMangas { get; set; }
        public DbSet<GeneroOrigenManga> generoOrigenMangas { get; set; }
        public DbSet<CapituloSheet> capituloSheets { get; set; }

    }
}
