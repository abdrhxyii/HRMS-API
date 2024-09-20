using HumanResource.Data;
using HumanResource.Exceptions;
using HumanResource.Interfaces.IServices;
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
        private readonly IPayrollService _payrollService;
        public PayrollController(ApplicationDbContext context, IPayrollService payrollService)
        {
            _context = context;
            _payrollService = payrollService;
        }

        [HttpPost("")]
        public async Task<ActionResult<PayrollModal>> CreatePayroll(PayrollModal payrollModal)
        {
            try
            {
                await _payrollService.AddPayrollAsync(payrollModal);
                return CreatedAtAction(nameof(CreatePayroll), new {id = payrollModal.PayrollID}, payrollModal);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<PayrollModal>>> GetAllPayroll()
        {
            var payrolls = await _context.Payrolls
            .Include(p => p.EmployeeModal)
            .Select(x => new {
                x.PayrollID,
                x.EmployeeModal.EmployeeID,
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
            try
            {
                var payroll = await _payrollService.RemoveAsync(id);
                if(payroll)
                {   
                    return NoContent();
                }else 
                {
                     return NotFound();
                }
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        
    }
}