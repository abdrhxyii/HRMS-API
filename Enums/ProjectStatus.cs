using System.ComponentModel.DataAnnotations;

namespace HumanResource.Enums
{
    public enum ProjectStatus
    {
        [Display(Name = "In Progress")]
        InProgress,
        [Display(Name = "Completed")]
        Completed
    }
}