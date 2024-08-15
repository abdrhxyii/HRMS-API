namespace HumanResource.ViewModals
{
    public class EmployeeTableViewModal
    {
        public int EmployeeIdManual {get; set;}
        public string? Image {get; set;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Designation { get; set; }

        public ICollection<ProfessionInfo> professionInfos {get; set;}

        public class ProfessionInfo
        {
            public string? EmployeeType { get; set; }
            public string? EmployeeStatus { get; set; } 
        }

    }
}
