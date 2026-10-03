using Biblioteca.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Dominio.Entities
{
    public class Multa:EntityBase
    {
        public float Monto { get; set; }

        public string? Comentario { get; set; }

        public EstadoMulta Estado {  get; set;}

        //Navegation Property

        public Socio Socios { get; set; } = null!;

        public Prestamo Prestamos { get; set; } = null!;
    }
}
