using System.ComponentModel.DataAnnotations;

namespace HumanResource.Modals
{
    public class EmployeeModal
    {   
        [Key]
        public int EmployeeID {get; set;}

        [Required]
        public int EmployeeIdManual {get; set;}

        public string? Image {get; set;}

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [Phone]
        public string MobileNumber { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [StringLength(20)]
        public string? MaritalStatus { get; set; }

        [StringLength(10)]
        public string? Gender { get; set; }

        [StringLength(50)]
        public string? Nationality { get; set; }

        [Required]
        public int ZIPCode {get; set;}

        [Required]
        public string Address {get; set;}

        [Required]
        public string Designation {get; set;}

        public int? CityId {get; set;}
        public virtual CityModal? CityModal {get; set;}

        public int? StateId {get; set;}
        public virtual StateModal? StateModal {get; set;}

        public ProfessionalEmployeeDetailsModal? ProfessionalEmployeeDetailsModal {get; set;}
        public EmployeeContactModal? EmployeeContactModal {get; set;}
        public ICollection<DocumentModal?> documents {get; set;}
    }
}