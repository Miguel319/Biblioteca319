using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaBOL
{
    public class Estatus
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Introduzca el nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Introduzca una breve descripción")]
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }

    }
}
