using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using HumanResource.Enums;

namespace HumanResource.Modals
{
    public class PayrollModal
    {
        [Key]
        public int PayrollID {get; set;}
        public int? EmployeeID {get; set;}
        public virtual EmployeeModal? EmployeeModal {get; set;}
        [Required]
        public int CostToCompany {get; set;}
        [Required]
        public int MonthlySalary {get; set;}
        public int? Deduction {get; set;}
        [Required]
        [EnumDataType(typeof(PayrollStatus))]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PayrollStatus PayrollStatus {get; set;} = PayrollStatus.Pending;
    }
}