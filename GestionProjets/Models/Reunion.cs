using System;
using System.Collections.Generic;
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
        [Required]
        public DateTime Date { get; set; }
        public DateTime DateCreation { get; set; } = DateTime.Now;
        [Required]
        public EtatReunion Etat { get; set; }

        public virtual ICollection<Utilisateur> Utilisateurs { get; set; }

        //Foreign keys
        [ForeignKey("Projet")]

        public Guid ProjetId { get; set; }
        public virtual Projet Projet { get; set; }
    }

    public class ReunionDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Nom { get; set; }
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public EtatReunion Etat { get; set; }
        public Guid ProjetId { get; set; }

    }

}
