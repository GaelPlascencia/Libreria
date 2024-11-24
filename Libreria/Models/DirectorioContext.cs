using Libreria.Models;
using Microsoft.EntityFrameworkCore;

namespace Libreria.Models
{
    public class DirectorioContext : DbContext
    {
        public DirectorioContext(DbContextOptions<DirectorioContext>options) : base(options)
        {
            
        }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<PedidoCliente> PedidosClientes { get; set; }
    }
}
