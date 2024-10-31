namespace SB.TechnicalChallenge.Application;
using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

public class GetOrganismByIdQueryHandler : IRequestHandler<GetOrganismByIdQuery, OrganismViewModel>
{
    private readonly IOrganismQueryRepository _organismQueryRepository;
    public GetOrganismByIdQueryHandler(IOrganismQueryRepository organismQueryRepository)
    {
        _organismQueryRepository = organismQueryRepository ?? throw new ArgumentNullException(nameof(organismQueryRepository));
    }

    public async Task<OrganismViewModel> Handle(GetOrganismByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _organismQueryRepository.GetById(request,cancellationToken);

        return result;
    }
}
