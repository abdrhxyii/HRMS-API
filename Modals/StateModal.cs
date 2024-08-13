using System.ComponentModel.DataAnnotations;

namespace HumanResource.Modals
{
    public class StateModal
    {
        [Key]
        public int StateId {get; set;}
        public string? StateName{get; set;}
    }
}