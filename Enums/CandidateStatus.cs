using System.ComponentModel.DataAnnotations;

namespace HumanResource.Enums
{
    public enum CandidateStatus
    {
        [Display(Name = "Selected")]
        Selected,
        [Display(Name = "InProgress")]
        InProgress,
        [Display(Name = "Rejected")]
        Rejected
    }
}