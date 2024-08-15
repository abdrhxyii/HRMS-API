using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanResource.Modals
{
    public class ProfessionalEmployeeDetailsModal
    {
        [Key]
        public int Id {get; set;}
        public int? EmployeeID { get; set; }
        public virtual EmployeeModal? EmployeeModal {get; set;}

        public string? Username { get; set; }
        public string? EmployeeType { get; set; }
        public string? EmployeeStatus { get; set; }

        public int? DepartmentId { get; set; }
        public virtual DepartmentModal? DepartmentModal { get; set; }

        public string? WorkingDays { get; set; }
        public DateTime JoiningDate { get; set; }
        
        public int? OfficeLocationId { get; set; }
        public virtual OfficeLocationModal? OfficeLocationModal { get; set; }        
    }
}