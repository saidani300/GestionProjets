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

        public Guid ParametreId { get; set; }
        public Parametre Parametre { get; set; }
    }

    public class EvaluationDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public long Note { get; set; }
        public Guid ParametreId { get; set; }
    }
}
