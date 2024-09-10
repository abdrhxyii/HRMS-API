using HumanResource.Modals;

namespace HumanResource.Interfaces.IServices
{
    public interface IStateService
    {
        Task<StateModal> AddStateAsync(StateModal stateModal);
        Task<StateModal> RemoveStateAsync(int id);
    }
}