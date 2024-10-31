namespace SB.TechnicalChallenge.Application;
using FluentValidation;

public class UpdateOrganismCommandValidation : AbstractValidator<UpdateOrganismCommand>
{
    public UpdateOrganismCommandValidation()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage(ValidationMessages.ES_REQUERIDO);
        RuleFor(x => x.Name).NotEmpty().WithMessage(ValidationMessages.ES_REQUERIDO);
    }
}
