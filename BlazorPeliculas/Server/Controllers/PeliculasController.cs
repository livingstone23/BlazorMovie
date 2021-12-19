using BlazorPeliculas.Server.Helpers;
using BlazorPeliculas.Shared.DTOs;
using BlazorPeliculas.Shared.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPeliculas.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeliculasController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        //private readonly IAlmacenadorDeArchivos almacenadorDeArchivos;

        public PeliculasController(ApplicationDbContext context)
        {
            this.context = context;
            //this.almacenadorDeArchivos = almacenadorDeArchivos;
        }

        //[HttpPost]
        //public async Task<ActionResult<int>> Post(Pelicula pelicula)
        //{
        //    if (!string.IsNullOrWhiteSpace(pelicula.Poster))
        //    {
        //        var fotoPersona = Convert.FromBase64String(pelicula.Poster);
        //        //pelicula.Poster = await almacenadorDeArchivos.GuardarArchivo(fotoPersona, "jpg", "peliculas");
        //    }

        //    if (pelicula.PeliculasActor != null)
        //    {
        //        for (int i = 0; i < pelicula.PeliculasActor.Count; i++)
        //        {
        //            pelicula.PeliculasActor[i].Orden = i + 1;
        //        }
        //    }

        //    context.Add(pelicula);
        //    await context.SaveChangesAsync();
        //    return pelicula.Id;
        //}



        [HttpPost]
        public async Task<ActionResult<int>> Post(Pelicula pelicula)
        {
            
            context.Add(pelicula);
            await context.SaveChangesAsync();
            return pelicula.Id;
        }



        [HttpGet]
        public async Task<ActionResult<HomePageDTO>> Get()
        {
            var limite = 6;

            var peliculasEnCartelera = await context.Peliculas
                .Where(x => x.EnCartelera).Take(limite)
                .OrderByDescending(x => x.Lanzamiento)
                .ToListAsync();

            var fechaActual = DateTime.Today;

            var proximosEstrenos = await context.Peliculas
                .Where(x => x.Lanzamiento > fechaActual)
                .OrderBy(x => x.Lanzamiento).Take(limite)
                .ToListAsync();

            var response = new HomePageDTO()
            {
                PeliculasEnCartelera = peliculasEnCartelera,
                ProximosEstrenos = proximosEstrenos
            };

            return response;

        }



        [HttpGet("{id}")]
        public async Task<ActionResult<PeliculaVisualizarDTO>> Get(int id)
        {
            var pelicula = await context.Peliculas.Where(x => x.Id == id)
                .Include(x => x.GenerosPelicula).ThenInclude(x => x.Genero)
                .Include(x => x.PeliculasActor).ThenInclude(x => x.Persona)
                .FirstOrDefaultAsync();

            if (pelicula == null) { return NotFound(); }

            // todo: sistema de votacion
            var promedioVotos = 4;
            var votoUsuario = 5;

            pelicula.PeliculasActor = pelicula.PeliculasActor.OrderBy(x => x.Orden).ToList();

            var model = new PeliculaVisualizarDTO();
            model.Pelicula = pelicula;
            model.Generos = pelicula.GenerosPelicula.Select(x => x.Genero).ToList();
            model.Actores = pelicula.PeliculasActor.Select(x =>
            new Persona
            {
                Nombre = x.Persona.Nombre,
                Foto = x.Persona.Foto,
                Personaje = x.Personaje,
                Id = x.PersonaId
            }).ToList();

            model.PromedioVotos = promedioVotos;
            model.VotoUsuario = votoUsuario;
            return model;
        }



    }

}
