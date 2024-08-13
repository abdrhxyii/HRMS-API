using System.ComponentModel.DataAnnotations;

namespace HumanResource.Modals
{
    public class OfficeLocationModal
    {
        [Key]
        public int OfficeLocationId { get; set; }
        public string? LocationName { get; set; }
    }
}