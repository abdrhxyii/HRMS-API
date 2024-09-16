using HumanResource.Exceptions;
using HumanResource.Interfaces.IRepositories;
using HumanResource.Interfaces.IServices;
using HumanResource.Modals;

namespace HumanResource.Services
{
    public class PayrollService : IPayrollService
    {
        private readonly IPayrollRepository _payrollRepo;
        private readonly IEmployeeRepository _employeeRepo;
        public PayrollService(IPayrollRepository payrollRepo, IEmployeeRepository employeeRepo)
        {
            _payrollRepo = payrollRepo;
            _employeeRepo = employeeRepo;
        }
        public async Task<PayrollModal> AddPayrollAsync(PayrollModal payrollModal)
        {
            if (payrollModal.EmployeeID == null)
            {
                throw new InvalidOperationException("Employee ID is required");
            }
            var employee = await _employeeRepo.FindEmployeeById(payrollModal.EmployeeID.Value); 

            if (employee == null)
            {
                throw new NotFoundException("Employee not found");
            }

            var payrollExistence = await _payrollRepo.Find(payrollModal.EmployeeID.Value);
            if(payrollExistence != null)
            {
                throw new ArgumentException($"Only One Payroll Can be Assigned/Created for '{payrollModal.EmployeeID}'");
            }

            return await _payrollRepo.AddPayroll(payrollModal);
        }

        public async Task<IEnumerable<PayrollModal>> GetAllAsync()
        {
            var payroll = await _payrollRepo.GetAll();
            if(!payroll.Any())
            {
                throw new NotFoundException("Payroll Does not exits");
            }
            return payroll;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            return await _payrollRepo.Remove(id);
        }

    }
}