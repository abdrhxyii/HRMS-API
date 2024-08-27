using HumanResource.Modals;
using HumanResource.ViewModels;

namespace HumanResource.Interfaces.IServices
{
    public interface IDepartmentService
    {
        Task<DepartmentModal> AddDepartmentAsync(DepartmentModal departmentModal);
        Task<IEnumerable<DepartmentModal?>> FindAllAsync();
        Task<DepartmentModal?> FindByIdAsync(int id);
        Task<bool?> RemoveAsync(int id);
        Task<IEnumerable<DepartmentEmployeeViewModel>> FindDeprtmentEmployeeAsync();
    }
}