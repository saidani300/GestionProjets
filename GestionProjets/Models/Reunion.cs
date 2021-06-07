using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateCreation { get; set; } = DateTime.Now;
        public EtatReunion Etat { get; set; }
        public Guid IdUser { get; set; }
        [ForeignKey("IdUser")]
        public Utilisateur utilisateur { get; set; }

        public Guid ProjetId { get; set; }
        [ForeignKey("ProjetId")]
        public Projet projet { get; set; }
    }
}
