using HumanResource.Data;
using HumanResource.Modals;
using Microsoft.AspNetCore.Mvc;

namespace HumanResource.Controllers
{
    [Route("city")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CityController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost("")]
        public async Task<ActionResult<CityModal>> CreateCity(CityModal cityModal)
        {
            _context.Cities.Add(cityModal);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(CreateCity), new { id = cityModal.CityId }, cityModal);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CityModal>> DeleteCityByID (int id)
        {
            var city = await _context.Cities.FindAsync(id);
            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        
    }
}