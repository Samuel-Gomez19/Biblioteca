using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Dominio.Entities
{
    public class Socio: EntityBase
    {
        public string PrimerNombre { get; set; } = string.Empty;

        public string Apellido { get; set; } = string.Empty;

        public string NumeroTelefono { get; set; } = string.Empty;

        public string CedulaCiudadania { get; set; } = string.Empty;

        // Navigation Properties

      

        public ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();

        public ICollection<Multa> Multas { get; set; } = new List<Multa>();
    }
}
