using HumanResource.Data;
using HumanResource.Interfaces.IRepositories;
using HumanResource.Modals;
using HumanResource.ViewModals;
using Microsoft.EntityFrameworkCore;

namespace HumanResource.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;
        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<EmployeeModal> AddEmployee(EmployeeModal employeeModal)
        {
            _context.Employees.Add(employeeModal);
            await _context.SaveChangesAsync();
            return employeeModal;
        }

        public async Task<IEnumerable<EmployeeModal>> FindAllEmployee()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<EmployeeModal?> FindEmployeeById(int id)
        {
            return await _context.Employees.FirstOrDefaultAsync(x => x.EmployeeID == id);
        }

        public async Task<bool> DeleteEmployeeById (int id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.EmployeeID == id);
            if(employee == null)
            {
                return false;
            }
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}