using HumanResource.Data;
using HumanResource.Interfaces.IRepositories;
using HumanResource.Interfaces.IServices;
using HumanResource.Modals;
using HumanResource.ViewModels;

namespace HumanResource.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentrepo;
        public DepartmentService(IDepartmentRepository departmentrepo)
        {
            _departmentrepo = departmentrepo;
        }
        public async Task<DepartmentModal> AddDepartmentAsync(DepartmentModal departmentModal)
        {
            return await _departmentrepo.AddDepartment(departmentModal);
        }

        public async Task<IEnumerable<DepartmentModal?>> FindAllAsync()
        {
            return await _departmentrepo.FindAll();
        }

        public async Task<DepartmentModal?> FindByIdAsync(int id)
        {
            return await _departmentrepo.FindById(id);
        }

        public async Task<IEnumerable<DepartmentEmployeeViewModel?>> FindDeprtmentEmployeeAsync()
        {
            return await _departmentrepo.FindDeprtmentEmployee();
        }

        public async Task<bool?> RemoveAsync(int id)
        {
            return await _departmentrepo.Remove(id);
        }

    }
}