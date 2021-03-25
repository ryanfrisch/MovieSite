using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieSite.Models
{
    public class MovieSiteContext : DbContext
    {
        public MovieSiteContext (DbContextOptions<MovieSiteContext> options) : base (options)
        {  }

        public DbSet<Movie> Movies { get; set; }
    }
}
