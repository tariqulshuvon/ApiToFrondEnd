using FluentValidation;

namespace Employee.Core.CQRS.Employee.Query.Validator;

public class GetAllEmployeeByIdQueryValidator : AbstractValidator<GetAllEmployeeByIdQuery>
{
    public GetAllEmployeeByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is Required");
    }
}
