using HumanResource.Data;
using HumanResource.Modals;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HumanResource.Controllers
{
    [Route("payroll")]
    [ApiController]
    public class PayrollController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public PayrollController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("")]
        public async Task<ActionResult<PayrollModal>> CreatePayroll(PayrollModal payrollModal)
        {
            var employee = await _context.Employees.FindAsync(payrollModal.EmployeeID);
            if(payrollModal.EmployeeID == null)
            {
                return BadRequest("Please include the employee in the body");
            }
            if(employee == null){
                return NotFound("No Employee Found");
            }
            _context.Payrolls.Add(payrollModal);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(CreatePayroll), new {id = payrollModal.PayrollID}, payrollModal);
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<PayrollModal>>> GetAllPayroll()
        {
            var payrolls = await _context.Payrolls
            .Include(p => p.EmployeeModal)
            .Select(x => new {
                x.PayrollID,
                x.EmployeeModal.FirstName,
                x.EmployeeModal.LastName,
                x.CostToCompany,
                x.MonthlySalary,
                x.Deduction,
                x.PayrollStatus
            }).ToListAsync();
            return Ok(payrolls);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PayrollModal>> DeletePayroll (int id)
        {
            var payroll = await _context.Payrolls.FindAsync(id);
            if(payroll == null)
            {
                return NotFound();
            }
            _context.Payrolls.Remove(payroll);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        
    }
}