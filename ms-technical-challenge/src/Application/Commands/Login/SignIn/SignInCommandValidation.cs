namespace SB.TechnicalChallenge.Application;
using FluentValidation;

public class SignInCommandValidation : AbstractValidator<SignInCommand>
{
    public SignInCommandValidation()
    {
        RuleFor(x => x.UserName).NotEmpty().WithMessage(ValidationMessages.ES_REQUERIDO);
        RuleFor(x => x.Password).NotEmpty().WithMessage(ValidationMessages.ES_REQUERIDO);
    }
}
