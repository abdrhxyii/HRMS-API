using HumanResource.Modals;
using Microsoft.EntityFrameworkCore;
using HumanResource.Data;
using HumanResource.Interfaces.IRepositories;

namespace HumanResource.Repositories
{
    public class PayrollRepository : IPayrollRepository
    {
        private readonly ApplicationDbContext _context;
        public PayrollRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<PayrollModal> AddPayroll(PayrollModal payrollModal)
        {
            _context.Payrolls.Add(payrollModal);
            await _context.SaveChangesAsync();
            return payrollModal;
        }
        // public async Task<IEnumerable<PayrollModal>> GetAll()
        // {
        //     var payrolls = await _context.Payrolls
        //     .Include(p => p.EmployeeModal)
        //     .Select(x => new {
        //         x.PayrollID,
        //         x.EmployeeModal.EmployeeID,
        //         x.EmployeeModal.FirstName,
        //         x.EmployeeModal.LastName,
        //         x.CostToCompany,
        //         x.MonthlySalary,
        //         x.Deduction,
        //         x.PayrollStatus
        //     }).ToListAsync();
        //     return payrolls;
        // }
        public async Task<bool> Remove (int id)
        {
            var payrolls = await _context.Payrolls.FirstOrDefaultAsync(x => x.PayrollID == id);
            if(payrolls == null)
            {
                return false;
            }
            _context.Payrolls.Remove(payrolls);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<PayrollModal?> Find (int id)
        {
            return await _context.Payrolls.FindAsync(id);
        }

        public Task<IEnumerable<PayrollModal>> GetAll()
        {
            throw new NotImplementedException();
        }

    }
}