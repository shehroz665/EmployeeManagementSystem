using EmployeeManagementSystem.Core;
using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.DTOs;
using EmployeeManagementSystem.Entities;
using EmployeeManagementSystem.Enums;
using EmployeeManagementSystem.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EmployeeManagementSystem.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AppDbContext _context;
        public RoleRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResult<Role>> GetPaginatedAsync(PaginatedRequestDto request)
        {
            var query = _context.Roles.AsQueryable();
            if (!string.IsNullOrWhiteSpace(request.Search))
            {
                string searchTerm = request.Search.Trim().ToLower();
                query = query.Where(d => d.Name.ToLower().Contains(searchTerm));
            }
            query = request.SortColumn switch
            {
                1 => request.SortDirection == SortDirection.ASC
                    ? query.OrderBy(d => d.Id)
                    : query.OrderByDescending(d => d.Id),

                2 => request.SortDirection == SortDirection.ASC
                    ? query.OrderBy(d => d.Name)
                    : query.OrderByDescending(d => d.Name),

                _ => request.SortDirection == SortDirection.ASC
                    ? query.OrderBy(d => d.Id)
                    : query.OrderByDescending(d => d.Id)
            };
            int totalCount = await query.CountAsync();
            var items = await query
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();
            return new PagedResult<Role>
            {
                Items = items,
                TotalCount = totalCount,
                Page = request.Page,
                PageSize = request.PageSize
            };
        }
        public IQueryable<Role> GetAll()
        {
            return _context.Roles
                .AsNoTracking()
                .AsQueryable();
        }

        public async Task<Role?> GetRole(Expression<Func<Role, bool>> predicate)
        {
            return await _context.Roles.FirstOrDefaultAsync(predicate);
        }

        public async Task<Role> CreateAsync(RoleCreateRequestDto role)
        {
            var newRole = new Role
            {
                Name = role.Name,
                CreatedOn = DateTime.UtcNow
            };
            await _context.Roles.AddAsync(newRole);
            await _context.SaveChangesAsync();
            return newRole;
        }

        public async Task<Role?> UpdateAsync(RoleUpdateRequestDto role)
        {

            var existingRole = await GetRole(r => r.Id == role.Id);
            if (existingRole is null) return existingRole;
            existingRole.Name = role.Name;
            existingRole.UpdatedOn = DateTime.UtcNow;
            _context.Roles.Update(existingRole);
            await _context.SaveChangesAsync();
            return existingRole;
        }

        public async Task<bool> DeleteAsync(Role role)
        {
            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
