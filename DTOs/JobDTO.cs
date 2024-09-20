namespace HumanResource.DTOs
{
    public class JobDTO
    {
        public int JobID { get; set; }
        public string Title { get; set; }
        public string DepartmentName { get; set; }
        public string LocationName { get; set; }
        public int Salary { get; set; }
        public string JobStatus { get; set; }
        public string JobType { get; set; }
    }
}