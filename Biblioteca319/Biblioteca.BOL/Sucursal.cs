using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaBOL
{
    public class Sucursal
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Introduzca el nombre de la sucursal")]
        [StringLength(30, ErrorMessage = "Máximo: 30 caracteres")]
        public string Nombre { get; set; }
        [DisplayName("Dirección")]
        [Required(ErrorMessage = "Introduzca la dirección de la sucursal")]
        public string Direccion { get; set; }
        [DisplayName("Teléfono")]
        public string Telefono { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        [DisplayName("Fecha de apertura")]
        public DateTime FechaApertura { get; set; }


        public virtual IEnumerable<Cliente> Clientes { get; set; }
        public virtual IEnumerable<Activo> Activos { get; set; }

        public string ImagenURL { get; set; }


    }
}
