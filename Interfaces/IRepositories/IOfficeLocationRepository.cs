using HumanResource.Modals;

namespace HumanResource.Interfaces.IRepositories
{
    public interface IOfficeLocationRepository
    {
        Task<OfficeLocationModal> Add(OfficeLocationModal officeLocationModal);
    }
}