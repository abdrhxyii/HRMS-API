using HumanResource.Data;
using Microsoft.AspNetCore.Mvc;
using HumanResource.Modals;
using HumanResource.Interfaces.IServices;

namespace HumanResource.Controllers
{
    [Route("state")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IStateService _stateService;
        public StateController(IStateService stateService)
        {
            _stateService = stateService;
        }

        [HttpPost("")]
        public async Task<ActionResult<StateModal>> CreateState (StateModal stateModal)
        {
            try
            {
                await _stateService.AddStateAsync(stateModal);
                return CreatedAtAction(nameof(CreateState), new {id = stateModal.StateId}, stateModal);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<StateModal>> DeleteStateByID (int id)
        {
            try
            {   
                await _stateService.RemoveStateAsync(id);
                return NoContent();
            }
            catch(KeyNotFoundException ex)
            {
                return NotFound( ex.Message);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        
    }
}