using EmployeeManagementSystem.DTOs;
using EmployeeManagementSystem.Interfaces;
using FluentValidation;

namespace EmployeeManagementSystem.Validators
{
    public class UpdateRoleValidator : AbstractValidator<RoleUpdateRequestDto>
    {

        public UpdateRoleValidator(IRoleRepository _repository)
        {

            RuleFor(x => x.Name)
               .NotEmpty()
               .WithMessage("Role name is required.")
               .MaximumLength(25)
               .WithMessage("Role name must not exceed 25 characters.");

            RuleFor(x => x)
               .MustAsync(async (x, cancellationToken) =>
                   await _repository.IsRoleAlreadyExist(x.Id, x.Name)==false)
               .WithMessage("Role already exists.");
        }
    }
}
