using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using practicaWebApiManga.Entidad;

namespace practicaWebApiManga.Controllers
{
    [ApiController]
    [Route("api/genero")]
    public class GeneroController:ControllerBase
    {
        private readonly ApplicationDbContext context;

        public GeneroController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Genero>>> getGeneros()
        {
            return await context.generos.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> postGenero(Genero genero)
        {
            var generos = await context.generos.AnyAsync(x=> x.Nombre == genero.Nombre);

            if (generos)
            {
                return BadRequest($"Ese {genero.Nombre} ya existe");
            }
            
            context.Add(genero);
            await context.SaveChangesAsync();
            return Ok();

        }
    }
}
