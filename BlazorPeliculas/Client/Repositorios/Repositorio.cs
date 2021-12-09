﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorPeliculas.Shared.Entidades;

namespace BlazorPeliculas.Client.Repositorios
{
    public class Repositorio : IRepositorio
    {
        public List<Pelicula> ObtenerPeliculas()
        {
            return new List<Pelicula>()
{
                    new Pelicula(){Titulo = "Spider-Man: Far From Home", Lanzamiento  = new DateTime(2019, 7, 2)
                    , Poster="https://cronicaglobal.elespanol.com/uploads/s1/61/11/50/7/main-700b9bff30.jpeg"},
                    new Pelicula(){Titulo = "Moana", Lanzamiento  = new DateTime(2016, 11, 23)
                    , Poster="https://i.pinimg.com/736x/d5/1a/12/d51a12c0e614bdfaf4eccd859be9e4c4--cartoon-design-disney-wallpaper.jpg"},
                    new Pelicula(){Titulo = "Inception", Lanzamiento  = new DateTime(2010, 7, 16)
                    , Poster="https://1.bp.blogspot.com/-rOnPGT4DWnM/UlW7RfymSpI/AAAAAAAAE2I/bhMMoy8Dduw/s1600/Inception.jpg"}
                };
        }
    }
}