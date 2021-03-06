using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorPeliculas.Shared.Entidades
{

    public class GeneroPelicula
    {
        public string Id { get; set; }
        public int PeliculaId { get; set; }
        public int GeneroId { get; set; }

        public Genero Genero { get; set; }
        public Pelicula Pelicula { get; set; }

    }
}
