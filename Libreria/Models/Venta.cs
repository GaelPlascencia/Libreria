using System.ComponentModel.DataAnnotations;

namespace Libreria.Models
{
    public class Venta
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "La cantidad es obligatoria")]
        [Range(1, 9999, ErrorMessage = "La cantidad debe ser mayor a 0")]
        public int Cantidad { get; set; }
        [Required(ErrorMessage = "La fecha de venta es obligatoria")]
        public DateTime Fecha_Venta { get; set; }
        [Required(ErrorMessage = "El total es obligatorio")]
        [Range(0.00, 200000.00, ErrorMessage = "El total debe ser entre $0.00 y $200,000.00")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "El total debe tener máximo 2 decimales")]
        public decimal? Total { get; set; }

        //Navegación
        [Required(ErrorMessage = "Por favor, seleccione un libro")]
        virtual public int? LibroId { get; set; } // Foreign Key
        virtual public Libro? Libro { get; set; }
    }
}
