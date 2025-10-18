using API.Application.Models;

namespace API.Application.Interfaces
{
    public interface IAnimalRepository
    {
        // Devuelve todas las categorías en modo asíncrono
        Task<IEnumerable<Animal>> GetAllAsync();

        // Crea una nueva categoría y la persiste en BD
        Task<Animal> CreateAsync(Animal animal);

        // Devuelve una categoría por ID, o null si no existe
        //Task<Category?> GetByIdAsync(int id);

        // Actualiza una categoría existente
        //Task<Category> UpdateAsync(Category category);

        // Elimina una categoría por ID, devuelve true si existía, false si no
        //Task<bool> DeleteAsync(int id);

        // Devuelve una categoría por nombre
        //Task<Category?> GetByNameAsync(string name);

        //Devuelve una categoría por Name y ParentId
        //Task<Category?> GetByNameAndParentIdAsync(string name, int? parentId);
    }
}
