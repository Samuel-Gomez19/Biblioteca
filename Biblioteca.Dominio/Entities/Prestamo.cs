using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Dominio.Entities
{
    public class Prestamo: EntityBase
    { 
        public DateTime InicioPrestamo { get; set; }

        public DateTime FinalPrestamo { get; set; }

        public float Pago {  get; set;}


        //navegation properties 

        public Socio Socios { get; set; } = null!;

        public ICollection<Libro> Libros { get; set;  } = new List<Libro>();

        public ICollection<Multa> Multas { get; set; } = new List<Multa>();


    }

}
