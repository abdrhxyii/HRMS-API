using System.ComponentModel.DataAnnotations;

namespace HumanResource.Enums
{
    public enum PayrollStatus
    {
        [Display(Name = "Completed")]
        Completed,
        [Display(Name = "Pending")]
        Pending
    }
}