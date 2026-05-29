using EmployeeManagementSystem.DTOs;
using EmployeeManagementSystem.Entities;
using EmployeeManagementSystem.Interfaces;
using EmployeeManagementSystem.Validators;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _repository;
        public RoleService(IRoleRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<IEnumerable<Role>>> GetAllAsync()
        {
            var query = _repository.GetAll();

            var result = await query
                            .OrderBy(x => x.Name)
                            .ToListAsync();

            return Result.Ok<IEnumerable<Role>>(result);
        }

        public async Task<Result<Role?>> GetByIdAsync(int id)
        {
            return Result.Ok(await _repository.GetByIdAsync(id));
        }

        public async Task<Result<Role>> CreateAsync(RoleCreateRequestDto role)
        {
            var validator = new CreateRoleValidator(_repository);
            var validationResult = await validator.ValidateAsync(role);
            if (!validationResult.IsValid) { 
                return Result.Fail<Role>(validationResult.Errors.Select(x => x.ErrorMessage));
            }
            var result = await _repository.CreateAsync(role);
            return Result.Ok(result);
        }


    }
}
