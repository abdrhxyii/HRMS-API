using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using HumanResource.Enums;

namespace HumanResource.Modals
{
    public class AttendanceModal
    {
        [Key]
        public int Id {get; set;}
        public DateTime Date {get; set;}

        [DisplayFormat(DataFormatString = "{0:hh\\:mm tt}", ApplyFormatInEditMode = true)]
        public TimeSpan? ChecksIn {get; set;}

        [DisplayFormat(DataFormatString = "{0:hh\\:mm tt}", ApplyFormatInEditMode = true)]
        public TimeSpan? ChecksOut {get; set;}

        [DisplayFormat(DataFormatString = "{0:hh\\:mm tt}", ApplyFormatInEditMode = true)]
        public TimeSpan? Break {get; set;}

        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        public TimeSpan? WorkingHours {get; set;}

        [EnumDataType(typeof(AttendanceStatus))]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AttendanceStatus? AttendanceStatus {get; set;}
    }
}