using HumanResource.DTOs;
using HumanResource.Modals;

namespace HumanResource.Interfaces.IServices
{
    public interface IJobService
    {
        Task<JobModal> AddAsync(JobModal jobModal);
        Task<IEnumerable<JobDTO>> GetAllAsync();
    }
}