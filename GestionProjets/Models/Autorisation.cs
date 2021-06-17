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
        [Required]
        public string Reference { get; set; }
        [Required]
        [ForeignKey("Utilisateur")]

        public Guid UserId { get; set; }
        public virtual Utilisateur Utilisateur { get; set; }

    }
}
