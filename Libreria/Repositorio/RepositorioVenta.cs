using Libreria.Models;
using Microsoft.EntityFrameworkCore;

namespace Libreria.Repositorio
{
    public class RepositorioVenta : IRepositorioVenta
    {
        private readonly DirectorioContext _context;
        public RepositorioVenta(DirectorioContext context)
        {
            _context = context;
        }

        public async Task<Venta> Add(Venta venta)
        {
            await _context.Ventas.AddAsync(venta);
            await _context.SaveChangesAsync();
            return venta;
        }

        public async Task Delete(int id)
        {
            var venta = await _context.Ventas.FindAsync(id);
            if (venta != null)
            {
                _context.Ventas.Remove(venta);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Venta?> Get(int id)
        {
            return await _context.Ventas.FindAsync(id);
        }

        public async Task<List<Venta>> GetAll()
        {
            return await _context.Ventas.Include(r=>r.Libro).ToListAsync();
        }

        public async Task Update(int id, Venta venta)
        {
            var ventaActual = await _context.Ventas.FindAsync(id);
            if (ventaActual != null)
            {
                ventaActual.Cantidad = venta.Cantidad;
                ventaActual.Fecha_Venta = venta.Fecha_Venta;
                ventaActual.Total = venta.Total;

                await _context.SaveChangesAsync();
            }
        }
    }
}
