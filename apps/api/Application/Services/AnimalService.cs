using AutoMapper;
using API.Application.Models;
using API.Application.DTOs;
using API.Application.Interfaces;
using API.Application.Repositories;

namespace API.Application.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly IMapper _mapper = null!;

        public AnimalService(IAnimalRepository animalRepository, IMapper mapper)
        {
            _animalRepository = animalRepository;
            _mapper = mapper;
        }

        /// Agrega un nuevo registro de Animal.
        public async Task<Animal> CreateAsync(AnimalDto dto)
        {
            // Validación básica antes de insertar
            if (string.IsNullOrWhiteSpace(dto.Sex))
                throw new ArgumentException("El campo 'Sex' es obligatorio.");

            // Mapear el DTO a la entidad
            var entity = new Animal
            {
                OriginId = dto.OriginId,
                StatusId = dto.StatusId,
                StageId = dto.StageId,
                Sex = dto.Sex,
                Breed = dto.Breed,
                BirthDate = dto.BirthDate,
                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow
            };

            // Guardar
            await _animalRepository.CreateAsync(entity);
            return entity;
        }


        /*// Devuelve todos los animales registrados.
        public async Task<IEnumerable<AnimalDto>> GetAllAsync()
        {
            var animals = await _animalRepository.GetAllAsync();
            return animals;
        }*/


        public async Task<IEnumerable<AnimalDto>> GetAllAsync()
        {
            var animals = await _animalRepository.GetAllAsync();

            /*/ Mapeo manual (simple)
            var result = animals.Select(a => new AnimalDto
            {
                Id = a.Id,
                Origin = a.OriginId,
                Status = a.StatusId,
                Stage = a.StageId,
                Sex = a.Sex,
                Breed = a.Breed,
                Birthdate = a.BirthDate.ToString(),
                Created = a.Created.ToString(),
                Updated = a.Updated.ToString()
            });

            return result;*/

            return _mapper.Map<IEnumerable<AnimalDto>>(animals);
        }


    }
}
