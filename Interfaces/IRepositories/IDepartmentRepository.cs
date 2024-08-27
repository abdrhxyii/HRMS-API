using HumanResource.Modals;
using HumanResource.ViewModels;

namespace HumanResource.Interfaces.IRepositories
{
    public interface IDepartmentRepository
    {
        Task<DepartmentModal> AddDepartment(DepartmentModal departmentModal);
        Task<IEnumerable<DepartmentModal?>> FindAll();
        Task<DepartmentModal?> FindById(int id);
        Task<bool> Remove(int id);
        Task<IEnumerable<DepartmentEmployeeViewModel?>> FindDeprtmentEmployee ();
    }
}