using HumanResource.Data;
using HumanResource.Modals;
using Microsoft.AspNetCore.Mvc;

namespace HumanResource.Controllers
{
    [Route("project")]
    public class ProjectController : ControllerBase
    {
        private readonly ApplicationDbContext _context;   
        public ProjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("")]
        public async Task<ActionResult<ProjectModal>> CreateProject ([FromBody] ProjectModal projectModal)
        {
            if(string.IsNullOrEmpty(projectModal.ProjectName)){
                return BadRequest("Please enter a valid project name");
            }
            _context.Projects.Add(projectModal);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(CreateProject), new {id = projectModal.Id}, projectModal);
        }

        // [HttpGet("{id}")]
        // public async Task<ActionResult<IEnumerable<ProjectModal>>> GetProjectsByEmployee(int id)
        // {
        //     // var projects = await _context.
        // }
        
    }
}