using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcMovieWeb.Models;

namespace MvcMovieWeb.Data
{
    public class MvcMovieWebContext : DbContext
    {
        public MvcMovieWebContext (DbContextOptions<MvcMovieWebContext> options)
            : base(options)
        {
        }

        public DbSet<MvcMovieWeb.Models.Movie> Movie { get; set; } = default!;
    }
}
