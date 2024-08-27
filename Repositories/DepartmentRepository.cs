using HumanResource.Data;
using HumanResource.Interfaces.IRepositories;
using HumanResource.Modals;
using HumanResource.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace HumanResource.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;
        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<DepartmentModal> AddDepartment(DepartmentModal departmentModal)
        {
            _context.Departments.Add(departmentModal);
            await _context.SaveChangesAsync();
            return departmentModal;
        }

        public async Task<IEnumerable<DepartmentModal?>> FindAll()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<DepartmentModal?> FindById(int id)
        {
            return await _context.Departments
            .Where(x => x.DepartmentId == id)
            .Select(x => new DepartmentModal{
                DepartmentId = x.DepartmentId,
                DepartmentName = x.DepartmentName
            })
            .FirstOrDefaultAsync();
        }

        public async Task<bool> Remove(int id)
        {
            var department = await _context.Departments.FirstOrDefaultAsync(x => x.DepartmentId == id);
            if(department == null)
            {
                return false;
            }
            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<DepartmentEmployeeViewModel>> FindDeprtmentEmployee()
        {
            return await _context.Departments
            .Select(x => new DepartmentEmployeeViewModel{
                 DepartmentId = x.DepartmentId,
                 DepartmentName = x.DepartmentName,
                 Employees = _context.ProfessionalEmployeeDetails
                 .Where(p => p.DepartmentId == x.DepartmentId)
                 .Select(x => new DepartmentEmployeeViewModel.EmployeeInfo{
                    Image = x.EmployeeModal.Image,
                    FirstName = x.EmployeeModal.FirstName,
                    LastName = x.EmployeeModal.LastName,
                    Designation = x.EmployeeModal.Designation
                 }).ToList()
            }).ToListAsync();
        }
    }
}