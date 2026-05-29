using EmployeeManagementSystem.DTOs;
using EmployeeManagementSystem.Entities;

namespace EmployeeManagementSystem.Interfaces
{
    public interface IRoleRepository
    {
        IQueryable<Role> GetAll();
        Task<Role?> GetByIdAsync(int id);
        Task<Role?> GetByNameAsync(string name);
        Task<Role?> GetExistingRoleAsync(Role role);
        Task<Role> CreateAsync(RoleCreateRequestDto role);
        Task<Role?> UpdateAsync(Role role);
        Task<bool> DeleteAsync(Role role);
    }
}
