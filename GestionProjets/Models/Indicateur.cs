using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionProjets.Models
{
    public class Indicateur
    {
        public string Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public string Methode { get; set; }
        public long Val1 { get; set; }
        public long Val2 { get; set; }
        public string Unite { get; set; }
    }
}
