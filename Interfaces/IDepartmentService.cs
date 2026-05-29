using EmployeeManagementSystem.DTOs;
using EmployeeManagementSystem.Entities;
using FluentResults;

namespace EmployeeManagementSystem.Interfaces
{
    public interface IDepartmentService
    {
        Task<Result<IEnumerable<Department>>> GetAllAsync();
        Task<Result<Department?>> GetByIdAsync(int id);
        Task<Result<Department>> CreateAsync(DepartmentCreateRequestDto department);
        Task<Result<Department?>> UpdateAsync(DepartmentUpdateRequestDto department);
    }
}
