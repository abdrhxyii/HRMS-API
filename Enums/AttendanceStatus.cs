using System.ComponentModel.DataAnnotations;

namespace HumanResource.Enums
{
    public enum AttendanceStatus
    {
        [Display(Name = "On Time")]
        OnTime,
        [Display(Name = "Late")]
        Late
    }
}