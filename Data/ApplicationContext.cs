using CrudApplication1.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace CrudApplication1.Data
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext>options) :base(options)
        { }
        public DbSet<Product> Products { get; set; }
    }
}
