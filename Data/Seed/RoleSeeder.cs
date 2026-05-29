using EmployeeManagementSystem.Entities;

namespace EmployeeManagementSystem.Data.Seed
{
    public class RoleSeeder
    {
        public static List<Entities.Role> GetRoles()
        {
            return new List<Entities.Role>
            {
                new Role { Id = 1, Name = "Admin", CreatedOn = new DateTime(2026,1,1)  },
                new Role { Id = 2, Name = "Manager", CreatedOn = new DateTime(2026,1,1)  },
                new Role { Id = 3, Name = "Employee", CreatedOn = new DateTime(2026,1,1)  }
            };
        }
    }
}
