using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Models
{
    public class Interlude
    {
        public List<Letra> letra { get; set; }
        public int nivel { get; set; }
        public string sigla { get; set; }
    }
}
