using AutoMapper;
using API.Data;
using API.Application.Models;
using API.Application.DTOs;
using API.Application.Interfaces;
using API.Application.Repositories;
using Microsoft.EntityFrameworkCore;

namespace API.Application.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly IMapper _mapper = null!;
        private readonly ApplicationDbContext _context; // para validación de FK

        public AnimalService(IAnimalRepository animalRepository, IMapper mapper, ApplicationDbContext context)
        {
            _animalRepository = animalRepository;
            _mapper = mapper;
            _context = context;
        }

        public async Task<Animal> CreateAsync(AnimalDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Sex))
                throw new ArgumentException("El campo 'Sex' es obligatorio.");

            // Validar existencia de FKs antes de insertar
            bool originExists = await _context.Origins.AnyAsync(o => o.Id == dto.OriginId);
            bool statusExists = await _context.Statuses.AnyAsync(s => s.Id == dto.StatusId);
            bool stageExists  = dto.StageId == null || await _context.Stages.AnyAsync(st => st.Id == dto.StageId);

            if (!originExists || !statusExists || !stageExists)
                throw new ArgumentException("Uno o más identificadores (Origin, Status, Stage) no existen.");

            // Mapear el DTO a entidad
            var entity = _mapper.Map<Animal>(dto);
            entity.Created = DateTime.UtcNow;
            entity.Updated = DateTime.UtcNow;

            // Guardar en la base
            await _animalRepository.CreateAsync(entity);

            return entity;
        }

        public async Task<IEnumerable<AnimalDto>> GetAllAsync()
        {
            var animals = await _animalRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<AnimalDto>>(animals);
        }

        public async Task<Animal?> GetByIdAsync(int id)
        {
            return await _animalRepository.GetByIdAsync(id);
        }
    }
}

