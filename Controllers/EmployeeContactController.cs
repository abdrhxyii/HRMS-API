using HumanResource.Data;
using HumanResource.Modals;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HumanResource.Controllers
{
    [Route("contact")]
    [ApiController]
    public class EmployeeContactController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public EmployeeContactController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost("")]
        public async Task<ActionResult<EmployeeContactModal>> CreateEmployeeContact (EmployeeContactModal employeeContactModal)
        {
            var contextdetail = await _context.EmployeeContacts.FirstOrDefaultAsync(e => e.EmployeeID == employeeContactModal.EmployeeID);
            if(contextdetail != null)
            {
                return Conflict(new {message = "Contact for the employee is already exist"});
            }
            _context.EmployeeContacts.Add(employeeContactModal);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(CreateEmployeeContact), new {id = employeeContactModal.Id}, employeeContactModal);
        }
        
    }
}