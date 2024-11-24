using Microsoft.EntityFrameworkCore;
using Libreria.Repositorio;
using Libreria.Models;

namespace Libreria.Repositorio
{
    public class RepositorioClientes : IRepositorioCliente
    {
        private readonly DirectorioContext _context;

        public RepositorioClientes(DirectorioContext context)
        {
            _context = context;
        }

        public async Task<Cliente> Add(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task Delete(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Cliente>> GetAll()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Cliente?> Get(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task Update(int id, Cliente cliente)
        {
            var clienteActual = await _context.Clientes.FindAsync(id);
            if (clienteActual != null)
            {
                clienteActual.Nombre = cliente.Nombre;
                clienteActual.Correo = cliente.Correo;
                clienteActual.Telefono = cliente.Telefono;
                clienteActual.Direccion = cliente.Direccion;

                await _context.SaveChangesAsync();
            }
        }
    }
}
