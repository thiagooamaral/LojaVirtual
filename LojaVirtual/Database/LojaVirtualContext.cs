using LojaVirtual.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaVirtual.Database
{
    public class LojaVirtualContext : DbContext
    {
        //EF Core: ORM
        //ORM: Biblioteca para mapear objetos para o Banco de Dados relacional

        /*
         * Para fazer um migration:
         * Abrir console: Tools > NuGet Package Manager > Package Manager Console
         * Escrever: Add-Migration [Nome do Migration]
         * E por fim: Update-Database
         */

        public LojaVirtualContext(DbContextOptions<LojaVirtualContext> options) : base(options)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<NewsletterEmail> NewsletterEmails { get; set; }
        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
    }
}
