using Biblioteca.Dominio.Entities;
using Biblioteca.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Dominio.Entities
{
    public class Libro: EntityBase
    {

        public string NombreLibro { get; set; } = string.Empty;

        public string NombreAutor { get; set; } = string.Empty;


        public GenerosLibros Genero { get; set; }

        // Navegation properties

   

       

     
        public ICollection<PrestamoLibro> PrestamoLibros { get; set; } = new List<PrestamoLibro>();

   
        

    }
}
