using HumanResource.Modals;

namespace HumanResource.Interfaces.IRepositories
{
    public interface IDocumentRepository
    {
        Task<DocumentModal> Add(DocumentModal documentModal);
        Task<bool> Remove(int id);
    }
}