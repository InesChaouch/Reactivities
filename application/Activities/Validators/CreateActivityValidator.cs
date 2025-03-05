using System;
using application.Activities.Commands;
using application.Activities.DTOs;
using FluentValidation;

namespace application.Activities.Validators;

public class CreateActivityValidator : BaseActivityValidator<CreateActivity.Command, CreateActivityDto>
{
    public CreateActivityValidator() : base(x => x.ActivityDto)
    {
    }
}
