using System;
using application.Activities.Commands;
using application.Activities.DTOs;
using FluentValidation;

namespace application.Activities.Validators;

public class EditActivityValidator : BaseActivityValidator<EditActivity.Command, EditActivityDto>
{
    public EditActivityValidator() : base(x => x.ActivityDto)
    {
        RuleFor(x => x.ActivityDto.Id)
            .NotEmpty().WithMessage("Id is required");
            
    }
}
