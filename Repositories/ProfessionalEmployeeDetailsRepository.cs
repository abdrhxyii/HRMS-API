using HumanResource.Data;
using HumanResource.Interfaces.IRepositories;
using HumanResource.Modals;

namespace HumanResource.Repositories
{
    public class ProfessionalEmployeeDetailsRepository : IProfessionalEmployeeDetailsRepository
    {
        private readonly ApplicationDbContext _context;
        public ProfessionalEmployeeDetailsRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task<ProfessionalEmployeeDetailsModal> AddProfession(ProfessionalEmployeeDetailsModal professionalEmployeeDetailsModal)
        {
            throw new NotImplementedException();
        }
    }
}