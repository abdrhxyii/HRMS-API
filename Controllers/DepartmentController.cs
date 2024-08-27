using HumanResource.Data;
using HumanResource.DTOs;
using HumanResource.Interfaces.IServices;
using HumanResource.Modals;
using HumanResource.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HumanResource.Controllers
{
    [Route("department")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        private readonly ApplicationDbContext _context;
        public DepartmentController(ApplicationDbContext context, IDepartmentService departmentService)
        {
            _context = context;
            _departmentService = departmentService;
        }
        [HttpPost("")]
        public async Task<ActionResult<DepartmentModal>> CreateDepartment (DepartmentModal departmentModal)
        {
            _context.Departments.Add(departmentModal);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetDepartmentById), new {id = departmentModal.DepartmentId}, departmentModal);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentModal>> GetDepartmentById (int id )
        {
            var department = await _context.Departments
            .Where(x => x.DepartmentId == id)
            .Select(x => new {
                x.DepartmentId,
                x.DepartmentName
            }).FirstOrDefaultAsync();

            if(department == null)
            {
                return NotFound();
            }
            return Ok(department);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DepartmentModal>> DeleteDepartmentByID (int id)
        {
            var department = await _context.Departments.FindAsync(id);
            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<DepartmentModal>>> DetAllDepartment()
        {
            var department = await _context.Departments.ToListAsync();
            return Ok(department);
        }

        // [HttpGet("{id}/employee")]
        // public async Task<ActionResult<DepartmentEmployeeViewModel>> GetDepartmentWithEmployees(int id)
        // {
        //     var department = await _context.Departments
        //         .Where(e => e.DepartmentId == id)
        //         .Select(d => new DepartmentEmployeeViewModel{
        //             DepartmentId = d.DepartmentId,
        //             DepartmentName = d.DepartmentName,
        //             Employees = d.Employees.Select(e => new DepartmentEmployeeViewModel.EmployeeInfo{
        //                 FirstName = e.FirstName,
        //                 LastName = e.LastName,
        //                 Designation = e.Designation
        //             }).ToList()
        //         }).FirstOrDefaultAsync();
        //     return Ok(department);
        // }
        [HttpGet("employees")]
        public async Task<ActionResult<IEnumerable<DepartmentEmployeeViewModel>>> GetAllDepartmentsWithEmployees()
        {
            var department = await _context.Departments
            .Select(x => new DepartmentEmployeeViewModel{
                 DepartmentId = x.DepartmentId,
                 DepartmentName = x.DepartmentName,
                 Employees = _context.ProfessionalEmployeeDetails
                 .Where(p => p.DepartmentId == x.DepartmentId)
                 .Select(x => new DepartmentEmployeeViewModel.EmployeeInfo{
                    Image = x.EmployeeModal.Image,
                    FirstName = x.EmployeeModal.FirstName,
                    LastName = x.EmployeeModal.LastName,
                    Designation = x.EmployeeModal.Designation
                 }).ToList()
            }).ToListAsync();
            return Ok(department);

            //  var department = await _context.Departments
            // .Select(x => new DepartmentEmployeeViewModel{
            //      DepartmentId = x.DepartmentId,
            //      DepartmentName = x.DepartmentName,
            //      Employees = x.Employees.Select(d => new DepartmentEmployeeViewModel.EmployeeInfo{
            //         FirstName = d.FirstName,
            //         LastName = d.LastName,
            //         Designation = d.Designation
            //      }).ToList()
            // }).ToListAsync();
            // return Ok(department);
        }
    }
}