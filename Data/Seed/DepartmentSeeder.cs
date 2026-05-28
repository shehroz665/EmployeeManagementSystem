using EmployeeManagementSystem.Entities;

namespace EmployeeManagementSystem.Data.Seed
{
    public class DepartmentSeeder
    {
        public static List<Department> GetDepartments()
        {
            return new List<Department>
            {
                new Department { Id = 1, Name = "HR" },
                new Department { Id = 2, Name = "IT" },
                new Department { Id = 3, Name = "Finance" }
            };
        }
    }
}
