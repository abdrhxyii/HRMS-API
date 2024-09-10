using HumanResource.Modals;

namespace HumanResource.Interfaces.IRepositories
{
    public interface IProjectRepository
    {
        Task<ProjectModal> AddProject(ProjectModal projectModal);
    }
}