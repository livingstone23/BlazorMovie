using BlazorPeliculas.Shared.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPeliculas.Server.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PersonasController : ControllerBase
    {

        private readonly ApplicationDbContext context;

        public PersonasController(ApplicationDbContext context)
        {
            this.context = context;
        }


        [HttpPost]
        public async Task<ActionResult<int>> Post(Persona persona)
        {
            context.Add(persona);
            await context.SaveChangesAsync();
            return persona.Id;
        }


        [HttpGet]
        public async Task<ActionResult<List<Persona>>> Get()
        {
            return await context.Personas.ToListAsync();
            
        }

        [HttpGet("buscar/{textoBusqueda}")]
        public async Task<ActionResult<List<Persona>>> Get(string textoBusqueda)
        {
            if (string.IsNullOrWhiteSpace(textoBusqueda)) { return new List<Persona>(); }
            textoBusqueda = textoBusqueda.ToLower();
            return await context.Personas
                .Where(x => x.Nombre.ToLower().Contains(textoBusqueda)).ToListAsync();
        }


        //[HttpGet]
        //public async Task<ActionResult<List<Persona>>> Get([FromQuery] Paginacion paginacion)
        //{
        //    var queryable = context.Personas.AsQueryable();
        //    await HttpContext.InsertarParametrosPaginacionEnRespuesta(queryable, paginacion.CantidadRegistros);
        //    return await queryable.Paginar(paginacion).ToListAsync();
        //}

        //[HttpGet("{id}")]
        //public async Task<ActionResult<Persona>> Get(int id)
        //{
        //    var persona = await context.Personas.FirstOrDefaultAsync(x => x.Id == id);

        //    if (persona == null) { return NotFound(); }

        //    return persona;
        //}


    }
}
