using HumanResource.Exceptions;
using HumanResource.Interfaces.IRepositories;
using HumanResource.Interfaces.IServices;
using HumanResource.Modals;

namespace HumanResource.Services
{
    public class ProfessionalEmployeeDetailsService : IProfessionalEmployeeDetailsService
    {
        private readonly IProfessionalEmployeeDetailsRepository _professonalRepo;
        private readonly IDepartmentRepository _departmentRepo;
        public ProfessionalEmployeeDetailsService(IProfessionalEmployeeDetailsRepository professonalRepo, IDepartmentRepository departmentRepo)
        {
            _professonalRepo = professonalRepo;
            _departmentRepo = departmentRepo;
        }

        public async Task<ProfessionalEmployeeDetailsModal> AddProfessionAsync(ProfessionalEmployeeDetailsModal professionalEmployeeDetailsModal)
        {
            var department = await _departmentRepo.FindById(professionalEmployeeDetailsModal.DepartmentId.Value);
            if(department == null)
            {
                throw new NotFoundException("Department Not Found");
            }
            var employee = await _professonalRepo.FindEmployeeProfession(professionalEmployeeDetailsModal.EmployeeID.Value);
            if(employee != null)
            {
                throw new InvalidOperationException("Professional details for this employee already exist.");
            }
            if(employee == null)
            {
                throw new NotFoundException("Employee Not Found");
            }
            await _professonalRepo.AddProfession(professionalEmployeeDetailsModal);
            return professionalEmployeeDetailsModal;
        }

    }
}