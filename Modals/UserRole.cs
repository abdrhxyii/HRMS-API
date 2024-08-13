using System.ComponentModel.DataAnnotations;

namespace HumanResource.Modals
{
    public enum UserRole
    {
        [Display(Name = "User")]
        User,
        [Display(Name = "Admin")]
        Admin
    }
}
