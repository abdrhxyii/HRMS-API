using HumanResource.Modals;

namespace HumanResource.Interfaces.IServices
{
    public interface IDocumentService
    {
        Task<DocumentModal> AddAsync(DocumentModal documentModal);
        Task<bool> RemoveAsync(int id);
    }
}