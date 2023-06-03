using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using practicaWebApiManga.DTOs;
using practicaWebApiManga.Entidad;

namespace practicaWebApiManga.Controllers
{
    [ApiController]
    [Route("api/capituloManga")]
    public class CapituloMangaController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public CapituloMangaController(ApplicationDbContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> postCap(CapituloMangaCreacionDTO capituloMangaCreacionDTO)
        {
            
            if (capituloMangaCreacionDTO.OrigenDelMangaid == null)
            {
                return BadRequest();
            }

            var origenManga = await context.origenDelMangas.FirstOrDefaultAsync(or => or.OrigenDelMangaId == capituloMangaCreacionDTO.OrigenDelMangaid);

            if(origenManga is null)
            {
                return BadRequest($"Este {origenManga.OrigenDelMangaId} no exite");
            }

            var numeroCap = await context.capituloMangas.FirstOrDefaultAsync(ca => ca.OrigenDelMangaid == capituloMangaCreacionDTO.OrigenDelMangaid && ca.NumeroCap == capituloMangaCreacionDTO.NumeroCap );
            if (numeroCap !=null)
            {
                return BadRequest($"Este {numeroCap.NumeroCap} numero de cap ya a sido subido.");
            }

            if (capituloMangaCreacionDTO.UrlCap == null)
            {
                return BadRequest("Este campo es requerido");
            }

            var cap = mapper.Map<CapituloMangas>(capituloMangaCreacionDTO);
            AsignarOrdernSheet(cap);
            context.Add(cap);
            await context.SaveChangesAsync();
            return Ok();

        }
        [HttpGet("{idOriManga:int}")]
        public async Task<ActionResult<List<CapituloMangasDTO>>> getCapAll(int idOriManga)
        {
            var cap = await context.capituloMangas.Where(cap => cap.OrigenDelMangaid== idOriManga).ToListAsync();

            var caps = mapper.Map<List<CapituloMangasDTO>>(cap);
            return caps;


        }
        [HttpGet("sheet/{idOrigen:int}/{idcap:int}/{numeroCap:int}")]
        public async Task<ActionResult<CapituloMangasDTO>> getCapShee(int idOrigen, int idcap , int numeroCap)
        {
            var cap = await context.capituloMangas
                .Where(cap =>cap.OrigenDelMangaid==idOrigen && cap.CapituloMangasId == idcap && cap.NumeroCap == numeroCap)
                .Include(sheet => sheet.capituloSheets)
                .FirstOrDefaultAsync();

            var caps = mapper.Map<CapituloMangasDTO>(cap);
            return caps;


        }



        private void AsignarOrdernSheet(CapituloMangas cap)
        {
            if (cap.capituloSheets != null)
            {
                for (int i = 0; i < cap.capituloSheets.Count; i++)
                {
                    cap.capituloSheets[i].OrdenDeSheet = i;
                }

            }
        }

    }
}
