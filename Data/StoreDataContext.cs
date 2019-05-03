using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class StoreDataContext : DbContext
    {
        public DbSet<Usuarios> Usuarios { get; set; }
        public StoreDataContext(DbContextOptions options) : base(options)
        {
            
        }
       
    }
}