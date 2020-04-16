using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;

namespace Crudelicious.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options): base(options){}
        public DbSet<CDelicious> cDelicious {get;set;}
    }
}