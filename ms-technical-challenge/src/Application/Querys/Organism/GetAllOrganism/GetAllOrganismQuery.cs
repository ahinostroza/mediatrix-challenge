namespace SB.TechnicalChallenge.Application;
using System.Collections.Generic;
using MediatR;

public sealed record GetAllOrganismQuery() : IRequest<IEnumerable<OrganismViewModel>>;
