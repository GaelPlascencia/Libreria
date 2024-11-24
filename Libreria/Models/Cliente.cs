using System.ComponentModel.DataAnnotations;

namespace Libreria.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(50, ErrorMessage = "La longitud máxima es de 50 caracteres")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress(ErrorMessage = "Formato de correo inválido")]
        [StringLength(50, ErrorMessage = "La longitud máxima es de 50 caracteres")]
        public string? Correo { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [StringLength(10, ErrorMessage = "El teléfono debe tener exactamente 10 caracteres")]
        [MinLength(10, ErrorMessage = "El teléfono debe tener exactamente 10 caracteres")]
        public string? Telefono { get; set; }

        [StringLength(100, ErrorMessage = "La longitud máxima es de 100 caracteres")]
        public string? Direccion { get; set; }

        // Propiedad de navegación
        virtual public ICollection<PedidoCliente>? Pedidos { get; set; }
    }

}
