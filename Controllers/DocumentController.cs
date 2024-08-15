using HumanResource.Data;
using HumanResource.Modals;
using Microsoft.AspNetCore.Mvc;

namespace HumanResource.Controllers
{
    [Route("document")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public DocumentController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost("")]
        public async Task<ActionResult<DocumentModal>> CreateDocument (DocumentModal documentModal)
        {
            _context.Documents.Add(documentModal);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(CreateDocument), new {id = documentModal.DocumentId}, documentModal);
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<DocumentModal>> DeleteDocument(int id)
        {
            var document = await _context.Documents.FindAsync(id);
            _context.Documents.Remove(document);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}