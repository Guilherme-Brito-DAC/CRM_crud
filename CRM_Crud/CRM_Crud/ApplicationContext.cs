using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace CRM_Crud
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext([NotNullAttribute] DbContextOptions options) : base(options)
        {

        }
    }
}