using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionProjets.Models
{
    public class Mesure
    {
        public string Id { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public long Valeur { get; set; }
        public string IdIndicateur { get; set; }

    }
}
