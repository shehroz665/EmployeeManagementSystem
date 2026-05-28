namespace EmployeeManagementSystem.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<Employee> Employees { get; set; }
            = new List<Employee>();
    }
}
