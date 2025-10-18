using System.ComponentModel.DataAnnotations;

namespace API.Application.DTOs
{
    public class AnimalDto
    {
        [Required]
        public int OriginId { get; set; }

        [Required]
        public int StatusId { get; set; }

        public int? StageId { get; set; }

        [Required]
        [MaxLength(10)]
        [RegularExpression("^(hembra|macho)$", ErrorMessage = "El campo Sex debe ser 'hembra' o 'macho'.")]
        public string Sex { get; set; } = string.Empty;

        [MaxLength(10)]
        public string? Breed { get; set; }

        [Required]
        public DateOnly BirthDate { get; set; }
    }
}