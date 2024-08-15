using System.ComponentModel.DataAnnotations;

namespace HumanResource.Enums
{
    public enum AttendanceStatus
    {
        [Display(Name = "OnTime")]
        OnTime,
        [Display(Name = "Late")]
        Late
    }
}