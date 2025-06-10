using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateAPI.Models;
using RealEstateAPI.Services;

namespace RealEstateAPI.Controllers
{
    // Controllers/BrandController.cs
    [ApiController]
    [Route("api/[controller]")]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        public IActionResult GetAllBrands() => Ok(_brandService.GetAll());

        [HttpPost]
        public IActionResult CreateBrand([FromBody] BrandDto brand)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                _brandService.Create(brand);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { error = ex.Message });
            }
        }

        [HttpPut]
        public IActionResult UpdateBrand([FromBody] BrandDto brand)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                _brandService.Update(brand);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { error = ex.Message });
            }
        }

        [HttpDelete("{name}")]
        public IActionResult DeleteBrand(string name)
        {
            try
            {
                _brandService.Delete(name);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { error = ex.Message });
            }
        }

        [HttpGet("test-exception")]
        public IActionResult TestException()
        {
            throw new InvalidOperationException("Test exception from controller!");
        }
    }

}
