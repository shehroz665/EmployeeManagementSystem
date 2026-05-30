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
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _context;
        public DepartmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResult<Department>> GetPaginatedAsync(PaginatedRequestDto request)
        {
            var query = _context.Departments.AsQueryable();
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
            return new PagedResult<Department>
            {
                Items = items,
                TotalCount = totalCount,
                Page = request.Page,
                PageSize = request.PageSize
            };
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
