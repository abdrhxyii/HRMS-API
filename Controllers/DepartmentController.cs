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
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        [HttpPost("")]
        public async Task<ActionResult<DepartmentModal>> CreateDepartment (DepartmentModal departmentModal)
        {
            try
            {
                var department = await _departmentService.AddDepartmentAsync(departmentModal);
                return CreatedAtAction(nameof(GetDepartmentById), new {id = departmentModal.DepartmentId}, departmentModal);
            }
            catch(Exception ex)
            {   
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentModal>> GetDepartmentById (int id )
        {
            var department = await _departmentService.FindByIdAsync(id);
            return Ok(department);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DepartmentModal>> DeleteDepartmentByID (int id)
        {
            var department = await _departmentService.RemoveAsync(id);
            if(department == true)
            {
                return NoContent();
            }
            else 
            {
                return NotFound();
            }
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<DepartmentModal>>> GetAllDepartment()
        {
            var department = await _departmentService.FindAllAsync();
            return Ok(department);
        }

        [HttpGet("employees")]
        public async Task<ActionResult<IEnumerable<DepartmentEmployeeViewModel>>> GetAllDepartmentsWithEmployees()
        {
            try
            {
                var department = await _departmentService.FindDeprtmentEmployeeAsync();
                return Ok(department);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}