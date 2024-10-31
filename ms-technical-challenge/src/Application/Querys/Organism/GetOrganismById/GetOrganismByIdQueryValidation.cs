namespace SB.TechnicalChallenge.Application;
using FluentValidation;

public class GetOrganismByIdQueryValidation : AbstractValidator<GetOrganismByIdQuery>
{
    public GetOrganismByIdQueryValidation()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage(BusinessExceptionMessages.IdCannotBeNullOrEmpty);
    }
}
