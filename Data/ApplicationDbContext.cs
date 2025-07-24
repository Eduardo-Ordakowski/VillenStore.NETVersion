using Microsoft.EntityFrameworkCore;

namespace VillenStore._NET_Version.Data
{
    public class ApplicationDbContext : DbContext
    {

      public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
      {
      }
    }
}
