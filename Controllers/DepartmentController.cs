using HumanResource.Data;
using HumanResource.Modals;
using Microsoft.AspNetCore.Mvc;

namespace HumanResource.Controllers
{
    [Route("department")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public DepartmentController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost("")]
        public async Task<ActionResult<DepartmentModal>> CreateDepartment (DepartmentModal departmentModal)
        {
            _context.Departments.Add(departmentModal);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(CreateDepartment), new {id = departmentModal.DepartmentId}, departmentModal);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DepartmentModal>> DeleteDepartmentByID (int id)
        {
            var department = await _context.Departments.FindAsync(id);
            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}