using HumanResource.Exceptions;
using HumanResource.Interfaces.IRepositories;
using HumanResource.Interfaces.IServices;
using HumanResource.Modals;

namespace HumanResource.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepo;
        private readonly IEmployeeRepository _employeeRepo;
        public ProjectService(IProjectRepository projectRepo, IEmployeeRepository employeeRepo)
        {
            _projectRepo = projectRepo;
            _employeeRepo = employeeRepo;
        }
        public async Task<ProjectModal> AddProjectAsync(ProjectModal projectModal)
        {
            var employee = await _employeeRepo.FindEmployeeById(projectModal.EmployeeID);
            if(employee == null)
            {
                throw new NotFoundException("Employee Not Found");
            }
            if(string.IsNullOrEmpty(projectModal.ProjectName))
            {
                throw new InvalidOperationException("Please enter a valid project name");
            }
            await _projectRepo.AddProject(projectModal);
            return projectModal;
        }
    }
}