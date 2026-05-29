using EmployeeManagementSystem.DTOs;
using EmployeeManagementSystem.Interfaces;
using FluentValidation;

namespace EmployeeManagementSystem.Validators
{
    public class CreateDepartmentValidator : AbstractValidator<DepartmentCreateRequestDto>
    {
        public CreateDepartmentValidator(IDepartmentRepository repository)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Department name is required.")
                .MaximumLength(25)
                .WithMessage("Department name must not exceed 25 characters.")
                .MustAsync(async (name, cancellationToken) =>
                    await repository.GetDepartment(d => d.Name.ToLower() == name.ToLower()) is null)
                .WithMessage("Department already exists.");

        }
    }
}
