using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionProjets.Models
{
    public class Phase
    {
        public string Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public DateTime DateCreation { get; set; } = DateTime.Now;
        public DateTime DateModification { get; set; } = DateTime.Now;
        public IEnumerable<Action> Actions { get; set; }
    }
}