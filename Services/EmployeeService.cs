using HumanResource.Data;
using HumanResource.Exceptions;
using HumanResource.Interfaces.IRepositories;
using HumanResource.Interfaces.IServices;
using HumanResource.Modals;
using HumanResource.ViewModals;

namespace HumanResource.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ApplicationDbContext _context;
        public EmployeeService(IEmployeeRepository employeeRepository, ApplicationDbContext context)
        {
            _employeeRepository = employeeRepository;
            _context = context;
        }

        public async Task<EmployeeModal> AddEmplyeeAsync (EmployeeModal employeeModal)
        {
            if(employeeModal.CityId == null)
            {
                throw new ArgumentException("Please select a city");
            }
            if (employeeModal.StateId == null)
            {
                throw new ArgumentException("Please select a state");
            }
            return await _employeeRepository.AddEmployee(employeeModal);

        }
        public async Task<IEnumerable<EmployeeModal>> GetAllEmployeeAsync ()
        {
            var employees = await _employeeRepository.FindAllEmployee();
            if(employees == null)
            {
                throw new NotFoundException("No Employee Found");
            }
            return employees;
        }
        public async Task<EmployeeModal> GetEmployeeByIdAsync(int id)
        {
            var employee = await _employeeRepository.FindEmployeeById(id);
            if(employee == null)
            {
                throw new NotFoundException($"Employee with {id} cannot exist");
            }
            return employee;
        }
        public async Task<IEnumerable<EmployeeTableViewModal>> EmployeeViewTable()
        {
            var employees = await _employeeRepository.FindAllEmployee();
            if(employees.Count() == 0)
            {
                throw new NotFoundException("No Employee Found");
            }
            return employees.Select(x => new EmployeeTableViewModal{
                EmployeeIdManual = x.EmployeeIdManual,
                Image = x.Image,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Designation = x.Designation,
                professionInfos = _context.ProfessionalEmployeeDetails
                .Select(p => new EmployeeTableViewModal.ProfessionInfo{
                    EmployeeType = p.EmployeeType,
                    EmployeeStatus = p.EmployeeStatus
                }).ToList()
            }).ToList();
        }
        public async Task<bool> DeleteEmployeeByIdAsync(int id)
        {
            return await _employeeRepository.DeleteEmployeeById(id);
        }    
    }
}