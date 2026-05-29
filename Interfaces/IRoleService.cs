using EmployeeManagementSystem.DTOs;
using EmployeeManagementSystem.Entities;
using FluentResults;

namespace EmployeeManagementSystem.Interfaces
{
    public interface IRoleService
    {
        Task<Result<IEnumerable<Role>>> GetAllAsync();
        Task<Result<Role?>> GetByIdAsync(int id);
        Task<Result<Role>> CreateAsync(RoleCreateRequestDto role);
        Task<Result<Role?>> UpdateAsync(RoleUpdateRequestDto role);

    }
}
