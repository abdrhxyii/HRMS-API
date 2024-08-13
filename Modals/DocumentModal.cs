using System.ComponentModel.DataAnnotations;

namespace HumanResource.Modals
{
    public class DocumentModal
    {
        [Key]
        public int DocumentId { get; set; }

        public int? EmployeeID {get; set;}
        public virtual EmployeeModal? EmployeeModal {get; set;}
        
        public string? DocumentType { get; set; }
        public string? FilePath { get; set; }        
    }
}