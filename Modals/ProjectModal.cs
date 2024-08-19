using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using HumanResource.Enums;

namespace HumanResource.Modals
{
    public class ProjectModal
    {
        [Key]
        public int Id {get; set;}
        [Required]
        public int EmployeeID {get; set;}
        public virtual EmployeeModal? EmployeeModal {get; set;}
        [Required]
        public string ProjectName {get; set;}
        [Required]
        public DateTime StartDate {get; set;}
        [Required]
        public DateTime EndDate {get; set;}

        [EnumDataType(typeof(ProjectStatus))]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ProjectStatus? ProjectStatus {get; set;}        
    }
}