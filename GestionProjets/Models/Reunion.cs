using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionProjets.Models
{
    public enum EtatReunion
    {
        Nouveau,
        En_cours,
        Terminé,
    }
    public class Reunion
    {
        public string Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateCreation { get; set; } = DateTime.Now;
        public EtatReunion Etat { get; set; }
        public string IdUser { get; set; }
        public string IdProjet { get; set; }
        public IEnumerable<Action> Actions { get; set; }
    }
}
