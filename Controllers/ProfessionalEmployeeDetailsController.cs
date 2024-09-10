using HumanResource.Data;
using HumanResource.Exceptions;
using HumanResource.Interfaces.IServices;
using HumanResource.Modals;
using Microsoft.AspNetCore.Mvc;

namespace HumanResource.Controllers
{
    [Route("profession")]
    [ApiController]
    public class ProfessionalEmployeeDetailsController : ControllerBase
    {
        private readonly IProfessionalEmployeeDetailsService _professionService;
        public ProfessionalEmployeeDetailsController(ApplicationDbContext context, IProfessionalEmployeeDetailsService professionService)
        {
            _professionService = professionService;
        }

        [HttpPost("")]
        public async Task<ActionResult<ProfessionalEmployeeDetailsModal>> CreateProfessioanEmployeeDeatil(ProfessionalEmployeeDetailsModal professionalEmployeeDetailsModal)
        {
            try
            {
                await _professionService.AddProfessionAsync(professionalEmployeeDetailsModal);
                return CreatedAtAction(nameof(CreateProfessioanEmployeeDeatil), new {id = professionalEmployeeDetailsModal.Id}, professionalEmployeeDetailsModal);
            }
            catch(NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch(InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); 
            }
        }
        
    }
}