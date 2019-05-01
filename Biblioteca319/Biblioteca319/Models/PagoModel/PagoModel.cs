namespace Biblioteca319.Models.PagoModel
{
    public class PagoModel
    {
        public int TarjetaId { get; set; }
        public string Titulo { get; set; }
        public int ActivoId { get; set; }
        public string ImagenUrl { get; set; }
        public int NumCongelamientos { get; set; }
        public bool EstaPago { get; set; }
    }
}
