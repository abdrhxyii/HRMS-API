using HumanResource.DTOs;
using HumanResource.Interfaces.IRepositories;
using HumanResource.Interfaces.IServices;
using HumanResource.Modals;

namespace HumanResource.Services
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepo;
        public JobService(IJobRepository jobRepo)
        {
            _jobRepo = jobRepo;
        }
        public async Task<JobModal> AddAsync(JobModal jobModal)
        {
            return await _jobRepo.Add(jobModal);
        }

        public async Task<IEnumerable<JobDTO>> GetAllAsync()
        {
            return await _jobRepo.GetAll();
        }

    }
}