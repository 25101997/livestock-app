using Microsoft.AspNetCore.Mvc;
using API.Application.Models;
using API.Application.Interfaces;

using API.Application.DTOs;
using API.Application.Services;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> Add([FromBody] AnimalDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newAnimal = await _animalService.CreateAsync(dto);
            return Ok(newAnimal); 
        }
    }
}
