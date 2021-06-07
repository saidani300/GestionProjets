using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionProjets.Models
{
    public class Evaluation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public long Note { get; set; }
        public DateTime DateCreation { get; set; } = DateTime.Now;
        public DateTime DateModification { get; set; } = DateTime.Now;

        public Guid IdSource { get; set; }
        [ForeignKey("IdSource")]
        public Utilisateur utilisateur { get; set; }

        public Guid IdProjet { get; set; }
        [ForeignKey("IdProjet")]
        public Projet projet { get; set; }
    }
}
