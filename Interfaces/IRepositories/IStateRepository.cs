using HumanResource.Data;
using HumanResource.Modals;

namespace HumanResource.Interfaces.IRepositories
{
    public interface IStateRepository
    {
        Task<StateModal> AddState(StateModal stateModal);
        Task<StateModal> RemoveState(int id);
        Task<StateModal?> FindState(int id);
    }
}