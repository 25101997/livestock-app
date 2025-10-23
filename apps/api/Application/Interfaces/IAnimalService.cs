using API.Application.Models;
using API.Application.DTOs;

namespace API.Application.Interfaces
{
    public interface IAnimalService
    {
        // Retorna todas las categorías
        Task<IEnumerable<AnimalDto>> GetAllAsync();

        // Crea una categoría nueva
        Task<Animal> CreateAsync(AnimalDto dto);

        // Retorna una registro de la tabla por ID
        Task<Animal?> GetByIdAsync(int id);
    }
}
