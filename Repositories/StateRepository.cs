using HumanResource.Data;
using HumanResource.Interfaces.IRepositories;
using HumanResource.Modals;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HumanResource.Repositories
{
    public class StateRepository : IStateRepository
    {
        private readonly ApplicationDbContext _context;
        public StateRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<StateModal> AddState(StateModal stateModal)
        {
            _context.States.Add(stateModal);
            await _context.SaveChangesAsync();
            return stateModal;
        }

        public async Task<StateModal?> FindState(int id)
        {
            return await _context.States.FirstOrDefaultAsync(x => x.StateId == id);
        }
        public async Task<StateModal> RemoveState(int id)
        {
            var state = await _context.States.FindAsync(id);
            _context.States.Remove(state);
            await _context.SaveChangesAsync();
            return state;
        }
    }
}