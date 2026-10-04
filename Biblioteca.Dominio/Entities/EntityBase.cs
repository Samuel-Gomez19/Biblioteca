using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Dominio.Entities
{
    public abstract class EntityBase
    {
        public int ID {  get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt {  get; set; }

        public bool Eliminado { get; set; }
        public DateTime? EliminadoEn { get; set; }



    }
}
