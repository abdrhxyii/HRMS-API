using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HumanResource.Modals
{
    public class UserModal
    {
        [Key]
        public int Id {get; set;}

        [Required]
        [EmailAddress]
        public string EmailAddress {get; set;}

        [Required]
        public string Password {get; set;}

        [EnumDataType(typeof(UserRole))]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public UserRole? userRole {get; set;} = UserRole.Admin;
    }
}