using HumanResource.Data;
using HumanResource.Modals;
using HumanResource.ViewModals;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
// using Microsoft.AspNetCore.Authorization;

namespace HumanResource.Controllers
{
    [Route("employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("")]

        public async Task<ActionResult<EmployeeModal>> CreateEmployee([FromBody] EmployeeModal employeeModal)
        {
            try
            {
                if(employeeModal.CityId == null){
                    return BadRequest("Please select a city");
                }
                if(employeeModal.StateId == null){
                    return BadRequest("Please select a state");
                }
                _context.Employees.Add(employeeModal);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(CreateEmployee), new { id = employeeModal.EmployeeID }, employeeModal);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<EmployeeModal>>> GetAllEmployee ()
        {
            var employees = await _context.Employees
            .Include(e => e.ProfessionalEmployeeDetailsModal)
            .Include(ei => ei.EmployeeContactModal)
            .Include(o => o.documents)
            .Include(x => x.attendances)
            .Include(i => i.projects)
            .ToListAsync();
                        
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeModal>> GetEmployeeById (int id)
        {
            var employee = await _context.Employees
            .Include(e => e.ProfessionalEmployeeDetailsModal)
            .Include(d => d.EmployeeContactModal)
            .Include(xi => xi.documents)
            .FirstOrDefaultAsync(x => x.EmployeeID == id);
            if(employee == null){
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<EmployeeModal>> DeleteEmployeeById(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("table/all")]
        public async Task<ActionResult<IEnumerable<EmployeeTableViewModal>>> GetEmployeeTableView()
        {
            var employees = await _context.Employees
            .Select(x => new EmployeeTableViewModal{
                EmployeeIdManual = x.EmployeeIdManual,
                Image = x.Image,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Designation = x.Designation,
                professionInfos = _context.ProfessionalEmployeeDetails
                .Select(p => new EmployeeTableViewModal.ProfessionInfo{
                    EmployeeType = p.EmployeeType,
                    EmployeeStatus = p.EmployeeStatus
                }).ToList()
            }).ToListAsync();
            return Ok(employees);
        }
        
    }
}