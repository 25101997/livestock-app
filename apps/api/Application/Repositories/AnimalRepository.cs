using Microsoft.EntityFrameworkCore;
using API.Application.Models;
using API.Application.DTOs;
using API.Application.Interfaces;
using API.Data;

namespace API.Application.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly ApplicationDbContext _context;

        // Se inyecta el DbContext para interactuar con la BD
        public AnimalRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        //Debuelve todos los datos
        public async Task<IEnumerable<Animal>> GetAllAsync()
        {
            return await _context.Animals
                .AsNoTracking() // Acelera lecturas, no rastrea cambios
                .ToListAsync();
        }

        public async Task<Animal> CreateAsync(Animal animal)
        {
            _context.Animals.Add(animal);
            await _context.SaveChangesAsync();
            return animal;
        }

/*
        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _context.Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Category?> GetByNameAsync(string name)
        {
            // AsNoTracking para lectura sin rastreo
            return await _context.Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Name == name);
        }

        public async Task<Category?> GetByNameAndParentIdAsync(string name, int? parentId)
        {
            return await _context.Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Name == name && c.ParentId == parentId);
        }

*/
    }
}
