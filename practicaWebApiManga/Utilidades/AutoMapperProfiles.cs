﻿using AutoMapper;
using practicaWebApiManga.DTOs;
using practicaWebApiManga.Entidad;

namespace practicaWebApiManga.Utilidades
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CapituloMangaCreacionDTO, CapituloMangas>()
                .ForMember(cap => cap.capituloSheets, opciones=> opciones.MapFrom(MapCapituloSheet));
        }

        public List<CapituloSheet> MapCapituloSheet(CapituloMangaCreacionDTO capituloMangaCreacionDTO, CapituloMangas capituloMangas)
        {
            var resultado = new List<CapituloSheet>();
            if(capituloMangaCreacionDTO.UrlCap == null) { return resultado; }

            foreach (var capUrl in capituloMangaCreacionDTO.UrlCap)
            {
                resultado.Add(new CapituloSheet() { urlSheetM = capUrl });
               
            }
            return resultado;

        }
    }
}
