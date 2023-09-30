using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Core.CQRS.Employee.Command.Validation;

public class CreateStateCommandValidation : AbstractValidator<CreateStateCommand>
{

    public CreateStateCommandValidation()
    {
        RuleFor(x => x.state).NotEmpty();
    }
}
