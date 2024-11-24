using System.ComponentModel.DataAnnotations;

namespace Libreria.Models
{
    public class PedidoCliente
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "La fecha del pedido es obligatoria")]
        public DateTime Fecha_Pedido { get; set; }
        [Required(ErrorMessage = "La cantidad es obligatoria")]
        [Range(1, 9999, ErrorMessage = "La cantidad debe ser mayor a 0")]
        public int Cantidad { get; set; }
        [Required(ErrorMessage = "El estado es obligatorio")]
        [StringLength(20, ErrorMessage = "La longitud máxima es de 20 caracteres")]
        public string? Estado { get; set; }
        // Propiedades de navegación
        [Required(ErrorMessage = "El libro es obligatorio")]
        virtual public int? LibroId { get; set; }
        virtual public Libro? Libro { get; set; }
        [Required(ErrorMessage = "El cliente es obligatorio")]
        virtual public int? ClienteId { get; set; }
        virtual public Cliente? Cliente { get; set; }
    }
}
