using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Application.Models
{
    [Table("animal")]
    public class Animal
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        // Relaciones (FKs)
        [Column("origin")]
        [ForeignKey(nameof(Origin))]
        public int OriginId { get; set; }
        public virtual AnimalOrigin? Origin { get; set; }

        [Column("status")]
        [ForeignKey(nameof(Status))]
        public int StatusId { get; set; }
        public virtual AnimalStatus? Status { get; set; }

        [Column("stage")]
        [ForeignKey(nameof(Stage))]
        public int? StageId { get; set; }
        public virtual AnimalStage? Stage { get; set; }

        // Atributos propios
        [Column("sex"), MaxLength(10)]
        [Required]
        public string Sex { get; set; } = string.Empty;

        [Column("breed"), MaxLength(10)]
        public string? Breed { get; set; }

        [Column("birth_date")]
        [Required]
        public DateOnly BirthDate { get; set; }

        [Column("created")]
        public DateTime Created { get; set; } = DateTime.UtcNow;

        [Column("updated")]
        public DateTime Updated { get; set; } = DateTime.UtcNow;
    }
}

