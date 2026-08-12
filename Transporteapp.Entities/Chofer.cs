using System;

namespace TransporteApp.Entities
{
    public class Chofer
    {
        public int IdChofer { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Cedula { get; set; }
    }
}