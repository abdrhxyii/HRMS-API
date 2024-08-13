using System.ComponentModel.DataAnnotations;

namespace HumanResource.Modals
{
    public class EmployeeContactModal
    {   
        [Key]
        public int Id {get; set;}
        public int? EmployeeID { get; set; }
        public virtual EmployeeModal? EmployeeModal {get; set;}
        public string? SlackId { get; set; }
        public string? SkypeId { get; set; }
        public string? GithubId { get; set; } 
    }
}