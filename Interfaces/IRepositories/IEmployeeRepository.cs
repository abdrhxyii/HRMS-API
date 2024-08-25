using HumanResource.Modals;
using HumanResource.ViewModals;

namespace HumanResource.Interfaces.IRepositories
{
    public interface IEmployeeRepository
    {
        Task<EmployeeModal> AddEmployee(EmployeeModal employeeModal);
        Task<IEnumerable<EmployeeModal>> FindAllEmployee();
        Task<EmployeeModal?> FindEmployeeById(int id);
        Task<bool> DeleteEmployeeById (int id);
    }
}