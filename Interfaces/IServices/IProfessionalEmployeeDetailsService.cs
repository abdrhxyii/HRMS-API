using HumanResource.Modals;

namespace HumanResource.Interfaces.IServices
{
    public interface IProfessionalEmployeeDetailsService
    {
        Task<ProfessionalEmployeeDetailsModal> AddProfessionAsync(ProfessionalEmployeeDetailsModal professionalEmployeeDetailsModal);
    }
}