using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using HumanResource.Enums;

namespace HumanResource.Modals
{
    public class CandidateModal
    {   
        [Key]
        public int Id {get; set;}
        public int? JobID {get; set;}
        public virtual JobModal? JobModal {get; set;}
        [Required]
        public string Image {get; set;}
        [Required]
        public string CandidateName {get; set;}
        [Required]
        public string AppliedFor {get; set;}
        [Required]
        public DateTime AppliedDate {get; set;}
        [Required]
        public string EmailAddress {get; set;}
        [Required]
        public string MobileNumber {get; set;}
        [Required]
        [EnumDataType(typeof(CandidateStatus))]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public CandidateStatus CandidateStatus {get; set;} = CandidateStatus.InProgress;
        
    }
}