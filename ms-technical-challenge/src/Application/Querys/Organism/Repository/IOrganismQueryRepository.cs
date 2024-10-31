namespace SB.TechnicalChallenge.Application;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IOrganismQueryRepository
{
    Task<IEnumerable<OrganismViewModel>> GetAll(CancellationToken cancellationToken);
    Task<OrganismViewModel> GetById(GetOrganismByIdQuery request, CancellationToken cancellationToken);
}
