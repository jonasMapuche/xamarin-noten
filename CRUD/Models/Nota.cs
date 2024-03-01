using System.Collections.Generic;

namespace CRUD.Models
{
    public class Nota
    {
        public List<Letra> letra { get; set; }
        public int nivel { get; set; }
        public float frequencia { get; set; }
    }
}
