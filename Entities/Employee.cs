namespace EmployeeManagementSystem.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public decimal Salary { get; set; }
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }
        public int? RoleId { get; set; }
        public Role? Role { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedOn { get; set; }
    }
}
