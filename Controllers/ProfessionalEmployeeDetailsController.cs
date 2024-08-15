using HumanResource.Data;
using HumanResource.Modals;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HumanResource.Controllers
{
    [Route("profession")]
    [ApiController]
    public class ProfessionalEmployeeDetailsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ProfessionalEmployeeDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("")]
        public async Task<ActionResult<ProfessionalEmployeeDetailsModal>> CreateProfessioanEmployeeDeatil(ProfessionalEmployeeDetailsModal professionalEmployeeDetailsModal)
        {
            var department = await _context.Departments.AnyAsync(d => d.DepartmentId == professionalEmployeeDetailsModal.DepartmentId);
            if(!department){
                return NotFound(new { message = "Department Doet Not Exist"});
            }
            var professionDetail = await _context.ProfessionalEmployeeDetails.FirstOrDefaultAsync(e => e.EmployeeID == professionalEmployeeDetailsModal.EmployeeID);
            if(professionDetail != null){
                return Conflict(new { message = "Professional details for this employee already exist." });
            }
            _context.ProfessionalEmployeeDetails.Add(professionalEmployeeDetailsModal);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(CreateProfessioanEmployeeDeatil), new {id = professionalEmployeeDetailsModal.Id}, professionalEmployeeDetailsModal);
        }
        
    }
}