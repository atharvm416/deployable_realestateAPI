using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateAPI.Models;
using RealEstateAPI.Services;

namespace RealEstateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        public PizzaController()
        {
        }

        [HttpGet]
        public ActionResult<List<Pizza>> GetAll() => PizzaService.GetAll();

        [HttpGet("/getwithID/{id}")]
        public ActionResult<Pizza> Get(int id)
        {
            var pizza = PizzaService.Get(id);

            if (pizza == null)
                return NotFound();

            return pizza;
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Pizza pizza)
        {
            // Sample logic: fetch existing pizza, update its values, and return a result
            var existingPizza = PizzaService.Get(id); // Assume this fetches the pizza by id

            if (existingPizza == null)
            {
                return NotFound(); // Returns 404 if not found
            }

            existingPizza.Name = pizza.Name;
            existingPizza.IsGlutenFree = pizza.IsGlutenFree;

            PizzaService.Update(existingPizza); // Assume this updates the pizza in your data store

            return NoContent(); // 204 No Content (update was successful)
        }

        [HttpPost]
        public IActionResult Create(Pizza pizza)
        {
            PizzaService.Add(pizza);
            return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pizza = PizzaService.Get(id);

            if (pizza is null)
                return NotFound();

            PizzaService.Delete(id);

            return NoContent();
        }
    }
}
