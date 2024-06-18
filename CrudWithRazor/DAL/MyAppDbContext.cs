using CrudWithRazor.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudWithRazor.DAL
{
    public class MyAppDbContext : DbContext
    {
        public MyAppDbContext(DbContextOptions options) : base(options) //Constructor 
        {
            
        }

        public virtual DbSet<Product> Products { get; set; }
    }
}
