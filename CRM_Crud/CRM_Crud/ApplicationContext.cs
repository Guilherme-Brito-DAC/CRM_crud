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
        public DbSet<CRM_Crud.Models.Curso> Curso { get; set; }
    }
}