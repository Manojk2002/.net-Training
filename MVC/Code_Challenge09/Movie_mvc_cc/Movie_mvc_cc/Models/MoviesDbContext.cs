using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Movie_mvc_cc.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext() : base("name=MovieConnection") { }
        public DbSet<Movie> movies { get; set; }
    }
}