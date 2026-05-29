using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.DTOs;
using EmployeeManagementSystem.Entities;
using EmployeeManagementSystem.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AppDbContext _context;
        public RoleRepository(AppDbContext context)
        {
            _context = context;
        }
        public IQueryable<Role> GetAll()
        {
            return _context.Roles
                .AsNoTracking()
                .AsQueryable();
        }

        public async Task<Role?> GetByIdAsync(int id)
        {
            return await _context.Roles.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Role?> GetByNameAsync(string name)
        {
            return await _context.Roles.FirstOrDefaultAsync(r => r.Name.ToLower() == name.ToLower().Trim());
        }
        public async Task<Role?> GetExistingRoleAsync(Role role)
        {
            return await _context.Roles.FirstOrDefaultAsync(r => r.Id == role.Id);
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

        public async Task<Role?> UpdateAsync(Role role)
        {
            role.UpdatedOn = DateTime.UtcNow;
            _context.Roles.Update(role);
            await _context.SaveChangesAsync();
            return role;
        }

        public async Task<bool> DeleteAsync(Role role)
        {
            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
