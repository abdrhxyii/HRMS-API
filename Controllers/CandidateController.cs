using HumanResource.Data;
using HumanResource.Modals;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HumanResource.Controllers
{
    [Route("candidate")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CandidateController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("")]
        public async Task<ActionResult<CandidateModal>> CreateCandidate(CandidateModal candidateModal)
        {
            _context.Candidates.Add(candidateModal);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(CreateCandidate), new {id = candidateModal.Id}, candidateModal);
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<CandidateModal>>> GetAllCandidates()
        {
            var candidate = await _context.Candidates
            .Include(x => x.JobModal)
            .Select(e => new {
                e.Id,
                e.JobModal.Title,
                e.CandidateName,
                e.AppliedFor,
                e.AppliedDate,
                e.EmailAddress,
                e.MobileNumber,
                e.CandidateStatus
            }).ToListAsync();
            return Ok(candidate);
        }
        // p
    }
}