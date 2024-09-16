using HumanResource.Modals;
using Microsoft.EntityFrameworkCore;

namespace HumanResource.Interfaces.IRepositories
{
    public interface IPayrollRepository
    {
        Task<PayrollModal> AddPayroll(PayrollModal payrollModal);
        Task<IEnumerable<PayrollModal>> GetAll();
        Task<bool> Remove (int id);
        Task<PayrollModal?> Find (int id);
    }
}