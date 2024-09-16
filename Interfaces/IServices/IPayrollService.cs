using HumanResource.Modals;

namespace HumanResource.Interfaces.IServices
{
    public interface IPayrollService
    {
        Task<PayrollModal> AddPayrollAsync(PayrollModal payrollModal);
        Task<IEnumerable<PayrollModal>> GetAllAsync();
        Task<bool> RemoveAsync (int id);
    }
}