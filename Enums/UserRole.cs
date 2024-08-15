using System.ComponentModel.DataAnnotations;

namespace HumanResource.Enums
{
    public enum UserRole
    {
        [Display(Name = "User")]
        User,
        [Display(Name = "Admin")]
        Admin
    }
}
