using HumanResource.Data;
using HumanResource.Interfaces.IServices;
using HumanResource.Modals;
using Microsoft.AspNetCore.Mvc;

namespace HumanResource.Controllers
{
    [Route("officelocation")]
    [ApiController]
    public class OfficeLocationController : ControllerBase
    {
        private readonly IOfficeLocationService _officeService;
        public OfficeLocationController(IOfficeLocationService officeService)
        {
            _officeService = officeService;
        }
        [HttpPost("")]
        public async Task<ActionResult<OfficeLocationModal>> CreateOfficeLocation(OfficeLocationModal officeLocationModal)
        {
            try
            {
                await _officeService.AddAsync(officeLocationModal);
                return CreatedAtAction(nameof(CreateOfficeLocation), new {id = officeLocationModal.OfficeLocationId}, officeLocationModal);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}