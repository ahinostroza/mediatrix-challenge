namespace SB.TechnicalChallenge.Application;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using SB.TechnicalChallenge.Infrastructure;

public class GetAllOrganismQueryHandler : IRequestHandler<GetAllOrganismQuery, IEnumerable<OrganismViewModel>>
{
    private readonly IOrganismQueryRepository _organismQueryRepository;
    private readonly IMemoryCacheService _memoryCacheService;
    public GetAllOrganismQueryHandler(
        IOrganismQueryRepository organismQueryRepository,
        IMemoryCacheService memoryCacheService
        )
    {
        _organismQueryRepository = organismQueryRepository ?? throw new ArgumentNullException(nameof(organismQueryRepository));
        _memoryCacheService = memoryCacheService ?? throw new ArgumentNullException(nameof(memoryCacheService));
    }

    public async Task<IEnumerable<OrganismViewModel>> Handle(GetAllOrganismQuery request, CancellationToken cancellationToken)
    {
        //if (!_memoryCacheService.TryGetValue("GetOrganism", out IEnumerable<OrganismViewModel> result))
        //{
        //    result = await Get(cancellationToken);
        //    _memoryCacheService.SetValue("GetOrganism", result);
        //}

        return await Get(cancellationToken);
    }

    private async Task<IEnumerable<OrganismViewModel>> Get(CancellationToken cancellationToken)
    {
        var result = await _organismQueryRepository.GetAll(cancellationToken);

        return result;
    }
}
