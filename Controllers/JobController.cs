using HumanResource.Data;
using HumanResource.Modals;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HumanResource.Controllers
{
    [Route("job")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public JobController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("")]
        public async Task<ActionResult<JobModal>> CreateJobPost ([FromBody] JobModal jobModal)
        {
            _context.JobModals.Add(jobModal);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(CreateJobPost), new {id = jobModal.Id }, jobModal);
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<JobModal>>> GetJobs ()
        {
            var jobs = await _context.JobModals
            .Include(x => x.DepartmentModal)
            .Include(e => e.OfficeLocationModal)
            .Select(x => new {
                x.Title,
                x.DepartmentModal.DepartmentName,
                x.OfficeLocationModal.LocationName,
                x.Salary,
                x.JobStatus,
                x.JobType
            }).ToListAsync();
            return Ok(jobs);
        }

        
    }
}