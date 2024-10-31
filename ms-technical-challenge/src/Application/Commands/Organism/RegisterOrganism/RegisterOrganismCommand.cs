namespace SB.TechnicalChallenge.Application;
using System;
using MediatR;

public class RegisterOrganismCommand : IRequest<Guid>
{
    public string Name { get; set; }
}
