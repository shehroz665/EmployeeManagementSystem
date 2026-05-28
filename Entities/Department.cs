using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Entities
{
    public class Department
    {
        public int Id { get; set; }

        [MaxLength(25)]
        public string Name { get; set; } = null!;
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
