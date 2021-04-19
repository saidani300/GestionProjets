using System;
using System.Collections.Generic;

namespace GestionProjets.Models
{
    public enum StatutA
    {
        Nouveau,
        En_cours,
        Terminé,
        vérifié
    }
    public class Action
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public DateTime DateCreation { get; set; } = DateTime.Now;
        public DateTime DateModification { get; set; } = DateTime.Now;
        public DateTime DateD { get; set; }
        public DateTime DateF { get; set; }
        public IEnumerable<Tache> Taches { get; set; }
        public string PredAction { get; set; }
        public StatutA Statut { get; set; }
    }
}