using Libreria.Models;

namespace Libreria.Repositorio
{
    public interface IRepositorioPedidoCliente
    {
        Task<List<PedidoCliente>> GetAll();
        Task<PedidoCliente?> Get(int id);
        Task<PedidoCliente> Add(PedidoCliente pedidoCliente);
        Task Update(int id, PedidoCliente pedidoCliente);
        Task Delete(int id);
    }
}
