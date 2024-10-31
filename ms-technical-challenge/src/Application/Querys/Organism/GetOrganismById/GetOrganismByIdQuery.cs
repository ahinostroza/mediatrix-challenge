namespace SB.TechnicalChallenge.Application;
using System;
using MediatR;

public sealed record GetOrganismByIdQuery(Guid Id) : IRequest<OrganismViewModel>;
