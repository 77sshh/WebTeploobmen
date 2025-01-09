using Microsoft.EntityFrameworkCore;

namespace WebTeploobmen.Data
{
    public class WebTeploobmenContext : DbContext
    {
        public DbSet<Variant> Variants { get; set; }
        public DbSet<User> Users { get; set; }
        public WebTeploobmenContext(DbContextOptions<WebTeploobmenContext> options) : base(options)
        {

        }
    }
}
