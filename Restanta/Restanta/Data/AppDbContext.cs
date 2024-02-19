using Microsoft.EntityFrameworkCore;
using Restanta.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Restanta.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Actor> Actori { get; set; }

        public DbSet<Film> Filme { get; set; }
        public DbSet<ActoriFilme> ActoriFilme { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            base.OnModelCreating(modelBuilder);
        }
    }
}