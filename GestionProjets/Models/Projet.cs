using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Nom { get; set; }
        public string Description { get; set; }

        public Guid TypeId { get; set; }
        public TypeProjet TypeProjet { get; set; }

        public DateTime DateCreation { get; set; } = DateTime.Now;
        public DateTime DateModification { get; set; } = DateTime.Now;
        public DateTime DateD { get; set; }
        public DateTime DateF { get; set; }
        
        public Guid UserId { get; set; }
        public Utilisateur Utilisateur1 { get; set; }

        
        public Guid ChefId { get; set; }
        public Utilisateur Utilisateur2 { get; set; }

        public ICollection<Objectif> Objectifs { get; set; }
        public ICollection<Document> Documents { get; set; }
        public ICollection<Reunion> Reunions { get; set; }

        public ICollection<Phase> Phases { get; set; }
        public ICollection<Action> Actions { get; set; }

        public ICollection<Opportunite> Opportunites { get; set; }
        public ICollection<Risque> Risques { get; set; }

        public ICollection<Mesure> Mesures { get; set; }
        public ICollection<Evaluation> Evaluations { get; set; }

        public StatutP Statut { get; set; }

    }

    public class ProjetDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Nom { get; set; }
        public string Description { get; set; }
        public Guid TypeId { get; set; }

        public DateTime DateD { get; set; }
        public DateTime DateF { get; set; }

        public Guid UserId { get; set; }
        public Guid ChefId { get; set; }

        public ICollection<Phase> Phases { get; set; }

        public StatutP Statut { get; set; }

    }
}