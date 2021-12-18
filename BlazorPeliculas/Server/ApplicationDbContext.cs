﻿using BlazorPeliculas.Shared.Entidades;
using Microsoft.EntityFrameworkCore;

namespace BlazorPeliculas.Server
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            

        }


        protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<GeneroPelicula>(builder =>
            //    {
            //        builder.HasNoKey();
            //        //builder.ToTable("GeneroPelicula");
            //    });
            modelBuilder.Entity<GeneroPelicula>().HasNoKey();
            modelBuilder.Entity<GeneroPelicula>().HasKey(x => new { x.GeneroId, x.PeliculaId });
            modelBuilder.Entity<PeliculaActor>().HasKey(x => new { x.PeliculaId, x.PersonaId });

            base.OnModelCreating(modelBuilder);
        }



        public DbSet<GeneroPelicula> GenerosPeliculas { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<PeliculaActor> PeliculasActores { get; set; }



    }
}
