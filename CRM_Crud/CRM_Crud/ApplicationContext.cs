using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using CRM_Crud.Models;

namespace CRM_Crud
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext([NotNullAttribute] DbContextOptions options) : base(options)
        {

        }

        public ApplicationContext() 
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Curso>().HasKey(t => t.id);

            modelBuilder.Entity<Lead>().HasKey(t => t.id);

            modelBuilder.Entity<Inscricao>().HasKey(t => t.id);

            modelBuilder.Entity<Usuario>().HasKey(t => t.id);
        }

        public DbSet<CRM_Crud.Models.Usuario> Usuario { get; set; }
    }
}