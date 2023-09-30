using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Core.CQRS.Employee.Command.Validation;

public class UpdateStateCommandValidation : AbstractValidator<UpdateStateCommand>
{
    public UpdateStateCommandValidation()
    {
        RuleFor(x => x.id).NotEmpty().WithMessage("Id is Requered");
    }
}