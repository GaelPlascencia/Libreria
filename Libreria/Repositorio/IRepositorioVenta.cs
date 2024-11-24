using Libreria.Models;

namespace Libreria.Repositorio
{
    public interface IRepositorioVenta
    {
        Task<List<Venta>> GetAll();
        Task<Venta?> Get(int id);
        Task<Venta> Add(Venta venta);
        Task Update(int id, Venta venta);
        Task Delete(int id);
    }
}
