using Microsoft.EntityFrameworkCore;
using VillenStore._NET_Version.Models;

namespace VillenStore._NET_Version.Data
{
    // Recebe o contexto do DB;
    public class ApplicationDbContext : DbContext
    {
        // Recebe as opções de configuração do DB;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Criação do DbSet para o modelo de produto;
        public DbSet<ProductModel> Products { get; set; }
    }
}
