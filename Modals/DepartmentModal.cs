using System.ComponentModel.DataAnnotations;

namespace HumanResource.Modals
{
    public class DepartmentModal
    {
        [Key]
        public int DepartmentId {get; set;}
        public string? DepartmentName {get; set;}
    }
}