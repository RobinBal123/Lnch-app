using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MyController : ControllerBase
    {
        private readonly List<dynamic> restaurants = new()
        {
            new { Id = 1, Name = "Marrakesh", Location = "Solna" },
            new { Id = 2, Name = "Ica Maxi", Location = "Solna" },
            new { Id = 3, Name = "Matsu", Location = "Solna" },
            new { Id = 4, Name = "Max", Location = "Solna" },
            new { Id = 5, Name = "Burger Mansion", Location = "Solna" },
            new { Id = 6, Name = "Burger King", Location = "Solna" },
            new { Id = 7, Name = "McDonald's", Location = "Solna" },
            new { Id = 8, Name = "Kebab Kurdistan", Location = "Solna" }
        };

        // GET: api/My
        [HttpGet]
        public IActionResult GetRestaurants()
        {
            return Ok(restaurants);
        }

        // GET: api/My/{id}
        [HttpGet("{id}")]
        public IActionResult GetRestaurantById(int id)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.Id == id);
            if (restaurant == null)
            {
                return NotFound(new { Message = "Restaurant not found" });
            }
            return Ok(restaurant);
        }

        // POST: api/My
        [HttpPost]
        public IActionResult AddRestaurant([FromBody] dynamic newRestaurant)
        {
            restaurants.Add(newRestaurant);
            return CreatedAtAction(nameof(GetRestaurantById), new { id = newRestaurant.Id }, newRestaurant);
        }
    }
}
