using EmployeeManagementSystem.Entities;

namespace EmployeeManagementSystem.Data.Seed
{
    public class DepartmentSeeder
    {
        public static List<Department> GetDepartments()
        {
            return new List<Department>
            {
                new Department { Id = 1, Name = "HR", CreatedOn = new DateTime(2026,1,1) },
                new Department { Id = 2, Name = "IT", CreatedOn = new DateTime(2026,1,1) },
                new Department { Id = 3, Name = "Finance", CreatedOn = new DateTime(2026,1,1) }
            };
        }
    }
}
