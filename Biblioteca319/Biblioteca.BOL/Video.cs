using System.ComponentModel.DataAnnotations;

namespace BibliotecaBOL
{
    public class Video: Activo
    {
        [Required]
        public string Director { get; set; }
    }
}
