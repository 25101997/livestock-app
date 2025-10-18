using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Application.Models
{
    [Table("animal_origin")]
    public class AnimalOrigin
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        [Column("name")]
        public string name { get; set; } = string.Empty;

         // Relación inversa (opcional)
        public virtual ICollection<Animal> Animals { get; set; } = new List<Animal>();
    }
}