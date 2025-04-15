using ExamenProgramacionIII.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;

namespace ExamenProgramacionIII.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MetaPrincipal>()
                .HasMany(e => e.Tareas)
                .WithOne(e => e.Principal)
                .HasForeignKey(e => e.MetaPrincipalId);
            

            modelBuilder.Entity<Tarea>()
               .HasOne(e => e.Principal)
               .WithMany(e => e.Tareas)
               .HasForeignKey(e => e.MetaPrincipalId);
        }

        public DbSet<MetaPrincipal> MetasPrincipales { get; set; }

        public DbSet<Tarea> Tareas { get; set; }
    }
}
