using FluentValidation;
using MeetingMinutes.Application.ViewModels;

namespace MeetingMinutes.Application.Validators;

public class MeetingViewModelValidator : AbstractValidator<MeetingViewModel>
{
    public MeetingViewModelValidator()
    {
        RuleFor(x => x.CustomerType)
           .IsInEnum().WithMessage("Invalid Customer Type")
           .WithMessage("Invalid Customer Type");

        RuleFor(x => x.CustomerId)
           .GreaterThan(0)
           .WithMessage("Customer ID must be greater than 0");

        RuleFor(x => x.Place)
           .MinimumLength(5)
           .MaximumLength(200)
           .WithMessage("Place must be between 5 and 200 characters");

        RuleFor(x => x.ClientSide)
           .NotEmpty().WithMessage("Client Side cannot be empty")
           .MinimumLength(2).WithMessage("Client Side must be at least 2 characters long");

        RuleFor(x => x.HostSide)
           .NotEmpty().WithMessage("Host Side cannot be empty")
           .MinimumLength(2).WithMessage("Host Side must be at least 2 characters long");

        RuleFor(x => x.Agenda)
           .NotEmpty().WithMessage("Agenda cannot be empty")
           .MinimumLength(2).WithMessage("Agenda must be at least 2 characters long");

        RuleFor(x => x.Discussion)
           .NotEmpty().WithMessage("Discussion cannot be empty")
           .MinimumLength(2).WithMessage("Discussion must be at least 2 characters long");

        RuleFor(x => x.Decision)
           .NotEmpty().WithMessage("Decision cannot be empty")
           .MinimumLength(2).WithMessage("Decision must be at least 2 characters long");
    }
}