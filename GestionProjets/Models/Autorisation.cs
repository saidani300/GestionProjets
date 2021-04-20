using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionProjets.Models
{
    public class Autorisation
    {
        public string Id { get; set; }
        public string Reference { get; set; }
        public string IdUser { get; set; }
        public bool Etat { get; set; } = false;
    }
}
