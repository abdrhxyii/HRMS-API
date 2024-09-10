using HumanResource.Data;
using HumanResource.Interfaces.IRepositories;
using HumanResource.Modals;

namespace HumanResource.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDbContext _context;
        public ProjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ProjectModal> AddProject(ProjectModal projectModal)
        {
            _context.Projects.Add(projectModal);
            await _context.SaveChangesAsync();
            return projectModal;
        }

    }
}