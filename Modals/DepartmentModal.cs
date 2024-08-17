using System.ComponentModel.DataAnnotations;

namespace HumanResource.Modals
{
    public class DepartmentModal
    {
        [Key]
        public int DepartmentId {get; set;}
        public string? DepartmentName {get; set;}
        public ICollection<EmployeeModal> Employees  {get; set;} = new List<EmployeeModal>();
        public ICollection<JobModal> JobModals { get; set; } = new List<JobModal>();
        // if List is not used, then null until it's explicitly assigned.
    }
}