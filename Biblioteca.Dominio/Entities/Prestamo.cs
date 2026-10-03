using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Dominio.Entities
{
    public class Prestamo: EntityBase
    { 
        public DateTime InicioPrestamo { get; set; }

        public DateTime FinalPrestamo { get; set; }

        public DateTime? FechaDevolucion { get; set; }

        public decimal Pago {  get; set;}


        //navegation properties 

        public Socio Socio { get; set; } = null!;

        public int SocioId { get; set; }

        public ICollection<PrestamoLibro> PrestamoLibros { get; set; } = new List<PrestamoLibro>();

        public ICollection<Multa> Multas { get; set; } = new List<Multa>();


    }

}
