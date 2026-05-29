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

        public async Task<bool> IsRoleAlreadyExist(int id, string name)
        {
            return await _context.Roles.AnyAsync(r => r.Id != id 
            && r.Name.ToLower() == name.ToLower());
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

            var existingRole = await GetByIdAsync(role.Id);
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
