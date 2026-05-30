using EmployeeManagementSystem.Core;
using EmployeeManagementSystem.DTOs;
using EmployeeManagementSystem.Entities;
using System.Linq.Expressions;

namespace EmployeeManagementSystem.Interfaces
{
    public interface IRoleRepository
    {
        Task<PagedResult<Role>> GetPaginatedAsync(PaginatedRequestDto request);
        IQueryable<Role> GetAll();
        Task<Role?> GetRole(Expression<Func<Role, bool>> predicate);
        Task<Role> CreateAsync(RoleCreateRequestDto role);
        Task<Role?> UpdateAsync(RoleUpdateRequestDto role);
        Task<bool> DeleteAsync(Role role);
    }
}
