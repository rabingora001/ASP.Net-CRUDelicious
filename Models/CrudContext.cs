using Microsoft.EntityFrameworkCore;

namespace CRUDelicious.Models
{
    public class CrudContext : DbContext
    {
        public CrudContext(DbContextOptions<CrudContext> options) : base(options) { }

        public DbSet<Crud> dishes {get;set;}
        //table name in shcema from CrudShcema in appsettings.json

    }
}