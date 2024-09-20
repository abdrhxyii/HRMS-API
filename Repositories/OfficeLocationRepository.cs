using HumanResource.Data;
using HumanResource.Interfaces.IRepositories;
using HumanResource.Modals;

namespace HumanResource.Repositories
{
    public class OfficeLocationRepository : IOfficeLocationRepository
    {
        private readonly ApplicationDbContext _context;
        public OfficeLocationRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<OfficeLocationModal> Add(OfficeLocationModal officeLocationModal)
        {
            await _context.OfficeLocations.AddAsync(officeLocationModal);
            await _context.SaveChangesAsync();
            return officeLocationModal;
        }

    }
}