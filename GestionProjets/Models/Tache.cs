using System;

namespace GestionProjets.Models
{
    public enum StatutT
    {
        Nouveau,
        En_cours,
        Terminé,
        vérifié
    }
    public class Tache
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public DateTime DateCreation { get; set; } = DateTime.Now;
        public DateTime DateModification { get; set; } = DateTime.Now;
        public DateTime DateD { get; set; }
        public DateTime DateF { get; set; }
        public string PredTache { get; set; }
        public StatutT Statut { get; set; }
    }
}