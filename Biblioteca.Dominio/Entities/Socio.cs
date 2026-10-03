using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Dominio.Entities
{
    public class Socio: EntityBase
    {
        public string PrimerNombre { get; set; } = String.Empty;

        public string Apellido { get; set; } = String.Empty;

        public string NumeroTelefono { get; set; } = String.Empty;

        public string CedulaCiudadania { get; set; } = String.Empty;

        // Navigation Properties

        public ICollection<Libro>Libros { get; set; } = new List<Libro>();

        public ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();

        public ICollection<Multa> Multas { get; set; } = new List<Multa>();
    }
}
