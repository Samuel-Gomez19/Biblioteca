using Biblioteca.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Dominio.Entities
{
    public class Multa:EntityBase
    {
        public decimal Monto { get; set; }

        public string? Comentario { get; set; }

        public EstadoMulta Estado {  get; set;}

        //Navegation Property

        public int SocioId { get; set; }
        public Socio Socio { get; set; } = null!;

        public Prestamo Prestamo { get; set; } = null!;

        public int PrestamoId { get; set; }
    }
}
