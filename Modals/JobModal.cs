using System.ComponentModel.DataAnnotations;

namespace HumanResource.Modals
{
    public class JobModal
    {
        [Key]
        public int JobID {get; set;}
        [Required]
        public string Title {get; set;}
        public int? DepartmentId {get; set;}
        public DepartmentModal? DepartmentModal {get; set;}
        public int? OfficeLocationId {get; set;}
        public OfficeLocationModal? OfficeLocationModal {get; set;}
        [Required]
        public int Salary {get; set;}
        [Required]
        public string JobStatus {get; set;} // Active / InActive / Completed
        [Required]
        public string JobType {get; set;} // Office /WFH
        public ICollection<CandidateModal> candidateModals {get; set;} = new List<CandidateModal>();
    }
}