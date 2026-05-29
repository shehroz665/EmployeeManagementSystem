using EmployeeManagementSystem.DTOs;
using EmployeeManagementSystem.Interfaces;
using FluentValidation;

namespace EmployeeManagementSystem.Validators
{

    public class UpdateDepartmentValidator : AbstractValidator<DepartmentUpdateRequestDto>
    {
        public UpdateDepartmentValidator(IDepartmentRepository repository)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Department name is required.")
                .MaximumLength(25)
                .WithMessage("Department name must not exceed 25 characters.");

            RuleFor(x => x)
                 .MustAsync(async (dto, cancellationToken) =>
                    await repository.GetDepartment(d => d.Id!=dto.Id && d.Name.ToLower() == dto.Name.ToLower()) is null)
                .WithMessage("Department already exists.");

        }
    }
}
