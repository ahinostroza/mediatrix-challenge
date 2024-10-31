namespace SB.TechnicalChallenge.Application;
using System;
using MediatR;

public class DeleteOrganismCommand : IRequest<bool>
{
    public Guid Id { get; set; }
}
