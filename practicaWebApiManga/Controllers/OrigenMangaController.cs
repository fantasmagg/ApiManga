using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using practicaWebApiManga.DTOs;
using practicaWebApiManga.Entidad;

namespace practicaWebApiManga.Controllers
{
    [ApiController]
    [Route("api/manga")]
    public class OrigenMangaController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public OrigenMangaController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<OrigenDelMangaDTO>> getCapsManga(int id)
        {
            var capitulos = await context.origenDelMangas
                .AsNoTracking()
                .Include(g => g.Genero)
                .Include(ca => ca.CapituloMangas)
                .FirstOrDefaultAsync(c => c.OrigenDelMangaId == id);

            var orDTO = mapper.Map<OrigenDelMangaDTO>(capitulos);

            return orDTO;


        }
        [HttpGet("{nombre}")]
        public async Task<ActionResult<OrigenDelMangaDTO>> getMangaNombre(string nombre)
        {
            var manga = await context.origenDelMangas
                .AsNoTracking()
                .Include(genero => genero.Genero)
                .Include(caps => caps.CapituloMangas)
                .FirstOrDefaultAsync(x => x.titulo.Contains(nombre));

            var mangaDTO = mapper.Map<OrigenDelMangaDTO>(manga);
            return mangaDTO;

        }
        [HttpGet("parabanersprincipal")]
        public async Task<ActionResult<List<OrigenMangaBanersDTO>>> getParaBaners()
        {
            var mangaBaners = await context.origenDelMangas.ToListAsync();

            var mangas = mapper.Map<List<OrigenMangaBanersDTO>>(mangaBaners);

            return mangas;
        }
        [HttpGet("parabusqueda/{nombre}")]
        public async Task<ActionResult<List<OrigenMangaBanersDTO>>> getBanersBusqueda(string nombre)
        {
            var mangaBusqueda = await context.origenDelMangas.Where(mangas => mangas.titulo.Contains(nombre)).ToListAsync();

            var ma = mapper.Map<List<OrigenMangaBanersDTO>>(mangaBusqueda);
            return ma;

        }


        [HttpPost]
        public async Task<ActionResult> postO(OrigenDelManga origen)
        {
            context.Add(origen);
            await context.SaveChangesAsync();
            return Ok();

        }
    }
}
