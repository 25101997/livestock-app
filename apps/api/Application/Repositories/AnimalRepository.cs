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

        public async Task<Animal?> GetByIdAsync(int id)
        {
            return await _context.Animals
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}
