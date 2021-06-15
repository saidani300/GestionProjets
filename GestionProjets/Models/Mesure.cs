using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionProjets.Models
{
    public class Mesure
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public DateTime DateCreation { get; set; } = DateTime.Now;
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public long Valeur { get; set; }

        public Guid IndicateurId { get; set; }
        public Indicateur Indicateur { get; set; }
    }

    public class MesureDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public long Valeur { get; set; }
        public Guid IndicateurId { get; set; }
    }
}
