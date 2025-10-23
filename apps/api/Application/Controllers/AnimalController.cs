using Microsoft.AspNetCore.Mvc;
using API.Application.Models;
using API.Application.Interfaces;
using API.Application.DTOs;
using API.Application.Services;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalsController : ControllerBase
    {
        private readonly IAnimalService _animalService;

        public AnimalsController(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var animals = await _animalService.GetAllAsync();
            return Ok(animals);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AnimalDto dto)
        {
            try
            {
                var newAnimal = await _animalService.CreateAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = newAnimal.Id }, newAnimal);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = $"Error interno: {ex.Message}" });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var animal = await _animalService.GetByIdAsync(id);

            if (animal == null)
                return NotFound();

            return Ok(animal);
        }
    }
}
