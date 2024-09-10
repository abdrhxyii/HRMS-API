using HumanResource.Data;
using HumanResource.Exceptions;
using HumanResource.Interfaces.IServices;
using HumanResource.Modals;
using Microsoft.AspNetCore.Mvc;

namespace HumanResource.Controllers
{
    [Route("project")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpPost("")]
        public async Task<ActionResult<ProjectModal>> CreateProject ([FromBody] ProjectModal projectModal)
        {
            try
            {
                var project = await _projectService.AddProjectAsync(projectModal);
                return CreatedAtAction(nameof(CreateProject), new {id = projectModal.Id}, projectModal);
            }
            catch(NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch(InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status422UnprocessableEntity, ex);
            }
        }
    }
}