using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Dominio.Entities
{
    public class PrestamoLibro: EntityBase
    {
        public int PrestamoId { get; set; }
        public Prestamo Prestamo { get; set; } = null!;

        public int LibroId { get; set; }

        public Libro Libro { get; set; } = null!;

    }
}
