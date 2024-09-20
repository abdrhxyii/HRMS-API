using HumanResource.Data;
using HumanResource.Interfaces.IRepositories;
using HumanResource.Interfaces.IServices;
using HumanResource.Modals;
using Microsoft.AspNetCore.Mvc;

namespace HumanResource.Controllers
{
    [Route("document")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IDocumentService _docService;
        public DocumentController(ApplicationDbContext context, IDocumentService docService)
        {
            _context = context;
            _docService = docService;
        }
        [HttpPost("")]
        public async Task<ActionResult<DocumentModal>> CreateDocument (DocumentModal documentModal)
        {
            try
            {
                await _docService.AddAsync(documentModal);
                return CreatedAtAction(nameof(CreateDocument), new {id = documentModal.DocumentId}, documentModal);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }  
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<DocumentModal>> DeleteDocument(int id)
        {
            try
            {
                var document = await _docService.RemoveAsync(id);
                if(document)
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
    }
}