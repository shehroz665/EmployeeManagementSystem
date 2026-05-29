using EmployeeManagementSystem.DTOs;
using EmployeeManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EmployeeManagementSystem.Interfaces
{
    public interface IDepartmentRepository
    {
        IQueryable<Department> GetAll();
        Task<Department?> GetDepartment(Expression<Func<Department, bool>> predicate);
        Task<Department> CreateAsync(DepartmentCreateRequestDto department);
        Task<Department?> UpdateAsync(DepartmentUpdateRequestDto department);
        Task<bool> DeleteAsync(Department department);
    }
}
