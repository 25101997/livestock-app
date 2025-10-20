using API.Application.Models;
using API.Application.DTOs;

namespace API.Application.Interfaces
{
    public interface IAnimalRepository
    {
        // Devuelve todas las categorías en modo asíncrono
        Task<IEnumerable<Animal>> GetAllAsync();

        // Crea una nueva categoría y la persiste en BD
        Task<Animal> CreateAsync(Animal animal);
    }
}
