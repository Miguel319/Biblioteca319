using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaBOL
{
    public class Cliente
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Introduzca el nombre del cliente")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Introduzca el apellido del cliente")]
        public string Apellido { get; set; }
        [DisplayName("Dirección")]
        [Required(ErrorMessage = "Introduzca la dirección del cliente")]
        public string Direccion { get; set; }
        [DisplayName("Fecha de nacimiento")]
        public DateTime FechaNacimiento { get; set; }
        [DisplayName("Teléfono")]
        public string Telefono { get; set; }

        public virtual Tarjeta Tarjeta { get; set; }
        public virtual Sucursal SucursalAsociada { get; set; }


    }
}
