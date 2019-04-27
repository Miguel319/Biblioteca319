using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaBOL
{
    public class Libro : Activo
    {
        [Required(ErrorMessage = "Introduzca el ISBN del libro")]
        public string ISBN { get; set; }
        [Required(ErrorMessage = "Introduzca el nombre del autor")]
        public string Autor { get; set; }
        [Required(ErrorMessage = "Introduzca el Índice Dewey")]
        [DisplayName("Índice Dewey")]
        public string IndiceDewey{ get; set; } //Sistema de clasificación de bibliotecas
    }
}
