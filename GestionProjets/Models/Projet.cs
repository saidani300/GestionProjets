using System;
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
        [ForeignKey("TypeId")]
        public TypeProjet typeProjet { get; set; }

        public DateTime DateCreation { get; set; } = DateTime.Now;
        public DateTime DateModification { get; set; } = DateTime.Now;
        public DateTime DateD { get; set; }
        public DateTime DateF { get; set; }
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public Utilisateur utilisateur1 { get; set; }

        public Guid ChefId { get; set; }
        [ForeignKey("UserId")]
        public Utilisateur utilisateur2 { get; set; }

        public StatutP Statut { get; set; }

    }
}