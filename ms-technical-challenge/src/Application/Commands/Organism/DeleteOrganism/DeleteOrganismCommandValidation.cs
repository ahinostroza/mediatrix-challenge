namespace SB.TechnicalChallenge.Application;
using FluentValidation;

public class DeleteOrganismCommandValidation : AbstractValidator<DeleteOrganismCommand>
{
    public DeleteOrganismCommandValidation()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage(ValidationMessages.ES_REQUERIDO);
    }
}
