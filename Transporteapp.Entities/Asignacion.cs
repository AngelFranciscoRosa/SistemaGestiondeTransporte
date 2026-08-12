using System;

namespace TransporteApp.Entities
{
    public class Asignacion
    {
        public int IdAsignacion { get; set; }
        public int IdChofer { get; set; }
        public int IdAutobus { get; set; }
        public int IdRuta { get; set; }
        public DateTime Fecha { get; set; }
        public bool Activo { get; set; }
    }
}