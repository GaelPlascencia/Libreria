using Libreria.Models;
using Microsoft.EntityFrameworkCore;

namespace Libreria.Repositorio
{
    public class RepositorioPedidosClientes : IRepositorioPedidoCliente
    {
        private readonly DirectorioContext _context;

        public RepositorioPedidosClientes(DirectorioContext context)
        {
            _context = context;
        }

        public async Task<PedidoCliente> Add(PedidoCliente pedidoCliente)
        {
            await _context.PedidosClientes.AddAsync(pedidoCliente);
            await _context.SaveChangesAsync();
            return pedidoCliente;
        }

        public async Task Delete(int id)
        {
            var pedido = await _context.PedidosClientes.FindAsync(id);
            if (pedido != null)
            {
                _context.PedidosClientes.Remove(pedido);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<PedidoCliente>> GetAll()
        {
            return await _context.PedidosClientes.Include(p => p.Libro).Include(p => p.Cliente).ToListAsync();
        }

        public async Task<PedidoCliente?> Get(int id)
        {
            return await _context.PedidosClientes.FindAsync(id);
        }

        public async Task Update(int id, PedidoCliente pedidoCliente)
        {
            var pedidoActual = await _context.PedidosClientes.FirstOrDefaultAsync(p => p.Id == id);

            if (pedidoActual != null)
            {
                pedidoActual.Fecha_Pedido = pedidoCliente.Fecha_Pedido;
                pedidoActual.Cantidad = pedidoCliente.Cantidad;
                pedidoActual.Estado = pedidoCliente.Estado;
                if (pedidoActual.ClienteId != pedidoCliente.ClienteId)
                {
                    pedidoActual.ClienteId = pedidoCliente.ClienteId;
                }
                if (pedidoActual.LibroId != pedidoCliente.LibroId)
                {
                    pedidoActual.LibroId = pedidoCliente.LibroId;
                }
                await _context.SaveChangesAsync();
            }
        }

    }
}
