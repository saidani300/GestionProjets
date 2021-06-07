using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionProjets.Models
{
    public class Autorisation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Reference { get; set; }

        public Guid IdUser { get; set; }
        [ForeignKey("IdUser")]
        public Utilisateur utilisateur1 { get; set; }

        public Guid IdMembre { get; set; }
        [ForeignKey("IdMembre")]
        public Utilisateur utilisateur2 { get; set; }

        public bool Etat { get; set; } = false;
    }
}
