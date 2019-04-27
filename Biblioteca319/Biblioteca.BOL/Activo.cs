using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaBOL
{
    public abstract class Activo
    {
        public int Id { get; set; }
        [DisplayName("Título")]
        [Required(ErrorMessage = "Introduzca el título")]
        public string Titulo { get; set; }
        [DisplayName("Año")]
        [Required(ErrorMessage = "El año es obligatorio")]
        public int Anio { get; set; }
        [Required(ErrorMessage = "El estatus es obligatorio")]
        public Estatus Estatus { get; set; }
        public decimal Costo { get; set; }
        public string ImagenUrl { get; set; }
        [DisplayName("Copias")]
        public int NumCopias { get; set; }
        [DisplayName("Ubicación")]


        public virtual Sucursal Ubicacion { get; set; }
    }
}
