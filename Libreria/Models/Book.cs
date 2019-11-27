using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Libreria.Models
{
    public class Book
    {
        public string Copertina { get; set; }
        public string Titolo { get; set; }
        public string Autore { get; set; }

        public string DataAcquisto { get; set; }

        public bool Finito { get; set; }

    }
}
