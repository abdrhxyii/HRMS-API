using HumanResource.Modals;

namespace HumanResource.Interfaces.IServices
{
    public interface IProjectService
    {
        Task<ProjectModal> AddProjectAsync(ProjectModal projectModal);        
    }
}