using EmployeeManagementSystem.DTOs;
using EmployeeManagementSystem.Interfaces;
using FluentValidation;

namespace EmployeeManagementSystem.Validators
{
    public class CreateRoleValidator: AbstractValidator<RoleCreateRequestDto>
    {

        public CreateRoleValidator(IRoleRepository _repository) {
            
         RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Role name is required.")
            .MaximumLength(25)
            .WithMessage("Role name must not exceed 25 characters.")
            .MustAsync(async (name, cancellationToken) =>
                await _repository.GetRole(r => r.Name.ToLower() == name.ToLower().Trim()) is null)
            .WithMessage("Role already exists.");
        }
    }
}
