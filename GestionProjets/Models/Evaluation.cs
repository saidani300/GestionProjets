using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionProjets.Models
{
    public class Evaluation
    {
        public string Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public long Note { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateModification { get; set; }
        public string IdSource { get; set; }
    }
}
