namespace WebApi.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Dept_Id { get; set; }
        public Department Department { get; set; }  
    }
}
