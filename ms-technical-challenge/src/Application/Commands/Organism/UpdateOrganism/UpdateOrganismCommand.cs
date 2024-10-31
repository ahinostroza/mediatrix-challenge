namespace SB.TechnicalChallenge.Application;
using System;
using MediatR;

public class UpdateOrganismCommand : IRequest<bool>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}
