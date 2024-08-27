using HumanResource.Modals;

namespace HumanResource.Interfaces.IRepositories
{
    public interface IProfessionalEmployeeDetailsRepository
    {
        Task<ProfessionalEmployeeDetailsModal> AddProfession(ProfessionalEmployeeDetailsModal professionalEmployeeDetailsModal);
    }
}