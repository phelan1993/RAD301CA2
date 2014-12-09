﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace S00126107.Models
{
    public class MoviesDb : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<MovieCast> Casts { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public MoviesDb() : base("MovieDb") { }
    }
}