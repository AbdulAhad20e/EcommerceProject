using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure
{
    public class WebContextFactory : IDesignTimeDbContextFactory<WebContext>
    {
        public WebContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<WebContext>();

            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=\"E-Commerce Database\";Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

            return new WebContext(optionsBuilder.Options);
        }
    }
}
