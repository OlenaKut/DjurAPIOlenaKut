using DjurAPI.DAL;
using Microsoft.AspNetCore.Mvc;

namespace DjurAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AnimalController : ControllerBase
    {
        [HttpGet]
        public async Task<List<Models.Animal>> GetAllAnimals()
        {
            return await DAL.AnimalManager.GetAllAnimals();
        }

        [HttpGet("{id}")]
        public async Task<Models.Animal> GetAnimalById(int id)
        {
            return await DAL.AnimalManager.GetAnimalById(id);
        }
    }
}
