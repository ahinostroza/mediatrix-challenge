namespace SB.TechnicalChallenge.Application.Commands.Person.RegisterPerson;
using FluentValidation;

public class RegisterOrganismCommandValidation : AbstractValidator<RegisterOrganismCommand>
{
    public RegisterOrganismCommandValidation()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage(BusinessExceptionMessages.NameCannotBeNullOrEmpty);
    }
}
