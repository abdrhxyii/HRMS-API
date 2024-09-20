using HumanResource.Data;
using HumanResource.Interfaces.IRepositories;
using HumanResource.Modals;

namespace HumanResource.Repositories
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly ApplicationDbContext _context;
        public DocumentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DocumentModal> Add(DocumentModal documentModal)
        {
            await _context.Documents.AddAsync(documentModal);
            await _context.SaveChangesAsync();
            return documentModal;
        }

        public async Task<bool> Remove(int id)
        {
            var document = await _context.Documents.FindAsync(id);
            if(document != null)
            {
                _context.Documents.Remove(document);
                await _context.SaveChangesAsync();
                return true;
            }else{
                return false;
            }
        }

    }
}