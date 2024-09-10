using HumanResource.Interfaces.IRepositories;
using HumanResource.Interfaces.IServices;
using HumanResource.Modals;

namespace HumanResource.Services
{
    public class StateService : IStateService
    {
        private readonly IStateRepository _stateRepo;
        public StateService(IStateRepository stateRepo)
        {
            _stateRepo = stateRepo;
        }
        public async Task<StateModal> AddStateAsync(StateModal stateModal)
        {
            return await _stateRepo.AddState(stateModal);
        }

        public async Task<StateModal> RemoveStateAsync(int id)
        {
            var state = await _stateRepo.FindState(id);
            if(state == null)
            {
                throw new KeyNotFoundException($"State with id {id} not found.");
            }
            return await _stateRepo.RemoveState(id);
        }

    }
}