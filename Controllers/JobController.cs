using HumanResource.Data;
using HumanResource.DTOs;
using HumanResource.Interfaces.IServices;
using HumanResource.Modals;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HumanResource.Controllers
{
    [Route("job")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;
        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }

        [HttpPost("")]
        public async Task<ActionResult<JobModal>> CreateJobPost ([FromBody] JobModal jobModal)
        {
            try
            {
                await _jobService.AddAsync(jobModal);
                return CreatedAtAction(nameof(CreateJobPost), new {id = jobModal.JobID }, jobModal);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<JobDTO>>> GetJobs ()
        {
            try
            {
                var jobs = await _jobService.GetAllAsync();
                return Ok(jobs);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        
    }
}