using HumanResource.Data;
using HumanResource.Interfaces.IRepositories;
using HumanResource.Modals;
using Microsoft.EntityFrameworkCore;

namespace HumanResource.Repositories
{
    public class ProfessionalEmployeeDetailsRepository : IProfessionalEmployeeDetailsRepository
    {
        private readonly ApplicationDbContext _context;
        public ProfessionalEmployeeDetailsRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ProfessionalEmployeeDetailsModal> AddProfession(ProfessionalEmployeeDetailsModal professionalEmployeeDetailsModal)
        {
            _context.ProfessionalEmployeeDetails.Add(professionalEmployeeDetailsModal);
            await _context.SaveChangesAsync();
            return professionalEmployeeDetailsModal;
        }
        public async Task<ProfessionalEmployeeDetailsModal?> FindEmployeeProfession(int id)
        {
            return await _context.ProfessionalEmployeeDetails.FirstOrDefaultAsync(x => x.EmployeeID == id);
        }

    }
}