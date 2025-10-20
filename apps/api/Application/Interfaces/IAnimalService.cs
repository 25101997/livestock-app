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

        // Retorna una categoría por ID
        //Task<Category?> GetByIdAsync(int id);
    }
}
