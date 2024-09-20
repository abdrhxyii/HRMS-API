using HumanResource.Interfaces.IRepositories;
using HumanResource.Interfaces.IServices;
using HumanResource.Modals;

namespace HumanResource.Services
{
    public class OfficeLocationService : IOfficeLocationService
    {
        private readonly IOfficeLocationRepository _locationRepos;
        public OfficeLocationService(IOfficeLocationRepository locationRepos)
        {
            _locationRepos = locationRepos;
        }
        public async Task<OfficeLocationModal> AddAsync(OfficeLocationModal officeLocationModal)
        {
            return await _locationRepos.Add(officeLocationModal);
        }

    }
}