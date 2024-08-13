using System.ComponentModel.DataAnnotations;

namespace HumanResource.Modals
{
    public class CityModal
    {
        [Key]
        public int CityId {get; set;}

        public string? CityName{get; set;}
    }
}