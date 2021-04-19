using System;
using System.Collections.Generic;

namespace GestionProjets.Models
{
    public enum StatutP
    {
        Nouveau,
        En_cours,
        Terminé,
        vérifié
    }   
    public class Projet
    {
       public string Id { get; set; }
       public string Nom { get; set; }
       public string Description { get; set; }
        public TypeProjet Type { get; set; }
        public DateTime DateCreation { get; set; } = DateTime.Now;
        public DateTime DateModification { get; set; } = DateTime.Now;
        public DateTime DateD { get; set; }
       public DateTime DateF { get; set; }
       public StatutP Statut { get; set; }
        public IEnumerable<Phase> Phases { get; set; }
        public IEnumerable<Action> Actions { get; set; }

    }
}