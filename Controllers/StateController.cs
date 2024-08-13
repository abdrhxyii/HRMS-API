using HumanResource.Data;
using Microsoft.AspNetCore.Mvc;
using HumanResource.Modals;

namespace HumanResource.Controllers
{
    [Route("state")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public StateController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("")]
        public async Task<ActionResult<StateModal>> CreateState (StateModal stateModal)
        {
            _context.States.Add(stateModal);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(CreateState), new {id = stateModal.StateId}, stateModal);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<StateModal>> DeleteStateByID (int id)
        {
            var state = await _context.States.FindAsync(id);
            _context.States.Remove(state);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        
    }
}