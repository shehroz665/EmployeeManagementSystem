using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.DTOs;
using EmployeeManagementSystem.Entities;
using EmployeeManagementSystem.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EmployeeManagementSystem.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _context;
        public DepartmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<Department> GetAll()
        {
            return _context.Departments.AsNoTracking().AsQueryable();
        }

        public async Task<Department?> GetDepartment(Expression<Func<Department,bool>> predicate)
        {
            return await _context.Departments.FirstOrDefaultAsync(predicate);
        }

        public async Task<Department> CreateAsync(DepartmentCreateRequestDto department)
        {
            var newDepartment = new Department
            {
                Name = department.Name,
                CreatedOn = DateTime.UtcNow
            };
            await _context.Departments.AddAsync(newDepartment);
            await _context.SaveChangesAsync();
            return newDepartment;
        }

        public async Task<Department?> UpdateAsync(DepartmentUpdateRequestDto department)
        {
            var existingDepartment = await GetDepartment(d => d.Id == department.Id);
            if (existingDepartment is null) return existingDepartment;
            existingDepartment.Name = department.Name;
            existingDepartment.UpdatedOn = DateTime.UtcNow;
            _context.Departments.Update(existingDepartment);
            await _context.SaveChangesAsync();
            return existingDepartment;
        }

        public async Task<bool> DeleteAsync(Department department)
        {
            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
