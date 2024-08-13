using HumanResource.Data;
using HumanResource.Modals;
using Microsoft.AspNetCore.Mvc;

namespace HumanResource.Controllers
{
    [Route("officelocation")]
    [ApiController]
    public class OfficeLocationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public OfficeLocationController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost("")]
        public async Task<ActionResult<OfficeLocationModal>> CreateOfficeLocation(OfficeLocationModal officeLocationModal)
        {
            _context.OfficeLocations.Add(officeLocationModal);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(CreateOfficeLocation), new {id = officeLocationModal.OfficeLocationId}, officeLocationModal);
        }
    }
}