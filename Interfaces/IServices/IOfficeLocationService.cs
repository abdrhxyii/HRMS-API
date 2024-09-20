using HumanResource.Modals;

namespace HumanResource.Interfaces.IServices
{
    public interface IOfficeLocationService
    {
        Task<OfficeLocationModal> AddAsync(OfficeLocationModal officeLocationModal);
        
    }
}