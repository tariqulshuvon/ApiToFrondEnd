using FluentValidation;

namespace Employee.Core.CQRS.Employee.Command.Validation;

public class CreateEmployeeCommandValidation : AbstractValidator<CreateEmployeeCommand>
{
    public CreateEmployeeCommandValidation()
    {
        RuleFor(x => x.employee).NotEmpty();
    }
}
