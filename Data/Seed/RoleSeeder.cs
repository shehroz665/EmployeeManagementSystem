using EmployeeManagementSystem.Entities;

namespace EmployeeManagementSystem.Data.Seed
{
    public class RoleSeeder
    {
        public static List<Entities.Role> GetRoles()
        {
            return new List<Entities.Role>
            {
                new Role { Id = 1, Name = "Admin" },
                new Role { Id = 2, Name = "Manager" },
                new Role { Id = 3, Name = "Employee" }
            };
        }
    }
}
