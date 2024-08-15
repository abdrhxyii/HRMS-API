namespace HumanResource.ViewModels
{
    public class DepartmentEmployeeViewModel
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public List<EmployeeInfo> Employees { get; set; }

        public class EmployeeInfo
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Designation { get; set; }
        }
    }
}
