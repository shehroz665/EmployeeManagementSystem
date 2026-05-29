using EmployeeManagementSystem.DTOs;
using EmployeeManagementSystem.Entities;
using EmployeeManagementSystem.Interfaces;
using EmployeeManagementSystem.Validators;
using FluentResults;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _repository;
        public DepartmentService(IDepartmentRepository repository) {
            _repository = repository;
        }

        public async Task<Result<IEnumerable<Department>>> GetAllAsync()
            {
                var query = _repository.GetAll();
    
                var result = await query
                                .OrderBy(x => x.Name)
                                .ToListAsync();
            return Result.Ok<IEnumerable<Department>>(result);
        }

        public async Task<Result<Department?>> GetByIdAsync(int id)
        {
            return Result.Ok(await _repository.GetDepartment(d => d.Id == id));
        }

        public async Task<Result<Department>> CreateAsync(DepartmentCreateRequestDto department)
        {
            var validator = new CreateDepartmentValidator(_repository);
            var validationResult = await validator.ValidateAsync(department);
            if (!validationResult.IsValid)
            {
                return Result.Fail<Department>(validationResult.Errors.Select(x => x.ErrorMessage));
            }
            var result = await _repository.CreateAsync(department);
            return Result.Ok(result);
        }

        public async Task<Result<Department?>> UpdateAsync(DepartmentUpdateRequestDto department)
        {
            var validator = new UpdateDepartmentValidator(_repository);
            var validationResult = await validator.ValidateAsync(department);
            if (!validationResult.IsValid)
            {
                return Result.Fail<Department?>(validationResult.Errors.Select(x => x.ErrorMessage));
            }
            var result = await _repository.UpdateAsync(department);
            return Result.Ok(result);
        }
    }
}
