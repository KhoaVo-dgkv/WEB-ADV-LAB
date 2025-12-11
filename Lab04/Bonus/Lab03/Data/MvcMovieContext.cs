using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lab03.Models;

namespace Lab03.Data
{
    public class MvcMovieContext : DbContext
    {
        public MvcMovieContext (DbContextOptions<MvcMovieContext> options)
            : base(options)
        {
        }

        public DbSet<Lab03.Models.Movie> Movie { get; set; } = default!;
        public DbSet<Lab03.Models.Category> Category { get; set; } = default!;
        public DbSet<Lab03.Models.Customer> Customer { get; set; } = default!;
        public DbSet<Lab03.Models.Ticket> Ticket { get; set; } = default!;
    }
}
