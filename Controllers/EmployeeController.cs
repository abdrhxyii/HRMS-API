using HumanResource.Data;
using HumanResource.Exceptions;
using HumanResource.Interfaces.IRepositories;
using HumanResource.Interfaces.IServices;
using HumanResource.Modals;
using HumanResource.ViewModals;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HumanResource.Controllers
{
    [Route("employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost("")]

        public async Task<ActionResult<EmployeeModal>> CreateEmployee([FromBody] EmployeeModal employeeModal)
        {
            try
            {
                var employee = await _employeeService.AddEmplyeeAsync(employeeModal);
                return CreatedAtAction(nameof(GetEmployeeById), new {id = employee.EmployeeID}, employee);
            }
            catch(ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<EmployeeModal>>> GetAllEmployee ()
        {
            try
            {
                var employee = await _employeeService.GetAllEmployeeAsync();
                return Ok(employee);
            }
            catch(NotFoundException notfound)
            {
                return NotFound(notfound.Message);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeModal>> GetEmployeeById (int id)
        {
            try
            {
                var employee = await _employeeService.GetEmployeeByIdAsync(id);
                return Ok(employee);
            }
            catch(NotFoundException notfound)
            {
                return NotFound(notfound.Message);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<EmployeeModal>> DeleteEmployeeById(int id)
        {
            try
            {
                var employee = await _employeeService.DeleteEmployeeByIdAsync(id);
                if(employee)
                {
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("table")]
        public async Task<ActionResult<IEnumerable<EmployeeTableViewModal>>> GetEmployeeTableView()
        {
            try
            {
                var employee = await _employeeService.EmployeeViewTable();
                return Ok(employee);
            }
            catch(NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        
    }
}