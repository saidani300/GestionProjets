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

        [Required]
        public string Nom { get; set; }
        public string Description { get; set; }
        [Required]
        public long Note { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateCreation { get; set; } = DateTime.Now;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateModification { get; set; } = DateTime.Now;
        [Required]
        public Guid ParametreId { get; set; }
        public virtual Parametre Parametre { get; set; }

        //Foreign keys
        [ForeignKey("Opportunite")]
        public Guid? OpportuniteId { get; set; }
        public virtual Opportunite Opportunite { get; set; }

        [ForeignKey("Risque")]
        public Guid? RisqueId { get; set; }
        public virtual Risque Risque { get; set; }

    }

    public class EvaluationDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public string Nom { get; set; }
        public string Description { get; set; }
        [Required]
        public long Note { get; set; }
        [Required]
        public Guid ParametreId { get; set; }

        //Foreign keys
        public Guid? OpportuniteId { get; set; }

        public Guid? RisqueId { get; set; }

    }
}
