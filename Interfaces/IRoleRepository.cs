using EmployeeManagementSystem.DTOs;
using EmployeeManagementSystem.Entities;

namespace EmployeeManagementSystem.Interfaces
{
    public interface IRoleRepository
    {
        IQueryable<Role> GetAll();
        Task<Role?> GetByIdAsync(int id);
        Task<Role?> GetByNameAsync(string name);
        Task<bool> IsRoleAlreadyExist(int id,string name);
        Task<Role> CreateAsync(RoleCreateRequestDto role);
        Task<Role?> UpdateAsync(RoleUpdateRequestDto role);
        Task<bool> DeleteAsync(Role role);
    }
}
