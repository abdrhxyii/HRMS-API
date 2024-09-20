using HumanResource.DTOs;
using HumanResource.Modals;

namespace HumanResource.Interfaces.IRepositories
{
    public interface IJobRepository
    {
        Task<JobModal> Add(JobModal jobModal);
        Task<IEnumerable<JobDTO>> GetAll();
    }
}