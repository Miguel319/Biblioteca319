using System;
using System.Collections.Generic;
using BibliotecaBOL;

namespace Biblioteca.BLL
{
    public class DataHelper
    {
        public static List<string> SimplificarTiempo(IEnumerable<SucursalHoras> sucursalHoras)
        {
            var horas = new List<string>();

            foreach (var hora in sucursalHoras)
            {
                var dia = SimplificarDia(hora.DiaSemana);
                var apertura = SimplificarHora(hora.HoraApertura);
                var horaCierre = SimplificarHora(hora.HoraCierre);
                var resultado = $"{dia} {apertura} a {horaCierre}";

                horas.Add(resultado);
            }

            return horas;
        }

        public static string SimplificarDia(int numero)
             =>Enum.GetName(typeof(DayOfWeek), numero -1);


        public static string SimplificarHora(int hora)
            => TimeSpan.FromHours(hora).ToString("hh':'mm");

    }
}
