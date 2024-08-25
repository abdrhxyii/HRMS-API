using HumanResource.Modals;
using HumanResource.ViewModals;

namespace HumanResource.Interfaces.IServices
{
    public interface IEmployeeService
    {
        Task<EmployeeModal> AddEmplyeeAsync (EmployeeModal employeeModal);
        Task<IEnumerable<EmployeeModal>> GetAllEmployeeAsync ();
        Task<EmployeeModal> GetEmployeeByIdAsync(int id);
        Task<IEnumerable<EmployeeTableViewModal>> EmployeeViewTable();
        Task<bool> DeleteEmployeeByIdAsync(int id);
    }
}