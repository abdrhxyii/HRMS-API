using HumanResource.Data;
using HumanResource.Interfaces.IRepositories;
using HumanResource.Modals;
using Microsoft.EntityFrameworkCore;
using HumanResource.DTOs;

namespace HumanResource.Repositories
{
    public class JobRepository : IJobRepository
    {
        private readonly ApplicationDbContext _context;
        public JobRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<JobModal> Add(JobModal jobModal)
        {
            await _context.Jobs.AddAsync(jobModal);
            await  _context.SaveChangesAsync();
            return jobModal;
        }

        public async Task<IEnumerable<JobDTO>> GetAll()
        {
            var jobs = await _context.Jobs
            .Include(x => x.DepartmentModal)
            .Include(e => e.OfficeLocationModal)
            .Select(x => new JobDTO
            {
                JobID = x.JobID,
                Title = x.Title,
                DepartmentName = x.DepartmentModal.DepartmentName,
                LocationName = x.OfficeLocationModal.LocationName,
                Salary = x.Salary,
                JobStatus = x.JobStatus,
                JobType = x.JobType
            })
            .ToListAsync();
            return jobs;
        }

    }
}