using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.DTOs
{
    public class RoleUpdateRequestDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

    }
}
