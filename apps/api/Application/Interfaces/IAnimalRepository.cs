using API.Application.Models;
using API.Application.DTOs;

namespace API.Application.Interfaces
{
    public interface IAnimalRepository
    {
        // Devuelve todas las en modo asíncrono
        Task<IEnumerable<Animal>> GetAllAsync();

        // Crea una nueva y la persiste en BD
        Task<Animal> CreateAsync(Animal animal);

        // 
        Task<Animal?> GetByIdAsync(int id);

    }
}
