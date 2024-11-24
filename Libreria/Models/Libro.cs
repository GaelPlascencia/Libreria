using System.ComponentModel.DataAnnotations;

namespace Libreria.Models
{
    public class Libro
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(50, ErrorMessage = "La longitud máxima es de 50 caractéres")]
        public string? Titulo { get; set; }
        [Required(ErrorMessage = "El autor es obligatorio")]
        [StringLength(50, ErrorMessage = "La longitud máxima es de 50 caractéres")]
        public string? Autor { get; set; }
        [Required(ErrorMessage = "La categoria es obligatoria")]
        [StringLength(30, ErrorMessage = "La longitud máxima es de 30 caractéres")]
        public string? Categoria { get; set; }
        [Required(ErrorMessage = "El precio es obligatorio")]
        [Range(0.00, 2000.00, ErrorMessage = "El precio es de $0.00 a $2000.00")]
        //Investigada en internet
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "El precio debe tener máximo 2 decimales")]
        public decimal? Precio { get; set; }
        [Required(ErrorMessage = "El stock es obligatorio")]
        [Range(0, 9999, ErrorMessage = "El valor de stock va de 0 a 9999")]
        public int Stock { get; set; }
        [Required(ErrorMessage = "El valor mínimo es obligatorio")]
        [Range(0,99, ErrorMessage = "El valor mínimo es de 0 a 99")]
        public int? Nivel_minimo { get; set; }

        //Navegación
        virtual public ICollection<Venta>? Ventas { get; set; }
        virtual public ICollection<PedidoCliente>? PedidoClientes { get; set; }
    }
}
