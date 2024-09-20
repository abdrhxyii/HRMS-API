using HumanResource.Interfaces.IRepositories;
using HumanResource.Interfaces.IServices;
using HumanResource.Modals;

namespace HumanResource.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository _documentRepo;
        public DocumentService(IDocumentRepository documentRepo)
        {
            _documentRepo = documentRepo;
        }
        public async Task<DocumentModal> AddAsync(DocumentModal documentModal)
        {
            return await _documentRepo.Add(documentModal);
        }

        public async Task<bool> RemoveAsync(int id)
        {
            return await _documentRepo.Remove(id);
        }

    }
}