using Biblioteca.Dominio.Entities;
using Biblioteca.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Dominio.Entities
{
    public class Libro: EntityBase
    {

        public string NombreLibro { get; set; } = String.Empty;

        public string NombreAutor { get; set; } = String.Empty;

        public DateTime? HoraPrestamo { get; set; }

        public DateTime? HoraRegreso { get; set; }

        public GenerosLibros Genero { get; set; }

        // Navegation properties

        public Socio Socios { get; set; } = null!;

        public Prestamo Prestamos { get; set; } = null!;

    }
}
