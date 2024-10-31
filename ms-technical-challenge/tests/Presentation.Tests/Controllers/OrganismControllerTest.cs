namespace Presentation.Tests.Controllers;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SB.TechnicalChallenge.Application;
using SB.TechnicalChallenge.Presentation.Controllers;

public class OrganismControllerTest
{
    private readonly Mock<IMediator> _mediatorMock;
    private readonly OrganismController _organismController;

    public OrganismControllerTest()
    {
        _mediatorMock = new Mock<IMediator>();
        _organismController = new OrganismController(_mediatorMock.Object);
    }

    [Fact]
    public async Task GetAllOrganism_ShouldReturn_Ok()
    {
        // Arrange
        var query = new GetAllOrganismQuery();
        var cancelationToken = new CancellationToken();
        var response = new List<OrganismViewModel> { new OrganismViewModel { Name = "Senado de la República Dominicana" } };

        _mediatorMock.Setup(x => x.Send(query, cancelationToken)).ReturnsAsync(response);

        // Act
        var result = await _organismController.Get();

        // Assert

        ((ObjectResult)result).StatusCode.Should().Be((int)HttpStatusCode.OK);
        ((ObjectResult)result).Value.Should().BeEquivalentTo(response);
    }

    [Fact]
    public async Task GetByIdOrganism_ShouldReturn_Ok()
    {
        // Arrange
        var id = Guid.NewGuid();
        var query = new GetOrganismByIdQuery(id);
        var cancelationToken = new CancellationToken();
        var response = new OrganismViewModel { Id = id, Name = "Senado de la República Dominicana" };

        _mediatorMock.Setup(x => x.Send(query, cancelationToken)).ReturnsAsync(response);

        // Act
        var result = await _organismController.GetById(id);

        // Assert

        ((ObjectResult)result).StatusCode.Should().Be((int)HttpStatusCode.OK);
        ((ObjectResult)result).Value.Should().BeEquivalentTo(response);
    }

    [Fact]
    public async Task CreateOrganism_ShouldReturn_Created()
    {
        // Arrange
        var id = Guid.NewGuid();

        var command = new RegisterOrganismCommand
        {
            Name = "Senado de la República Dominicana"
        };

        var cancelationToken = new CancellationToken();

        _mediatorMock.Setup(x => x.Send(command, cancelationToken)).ReturnsAsync(id);

        // Act
        var result = await _organismController.Create(command);

        // Assert

        ((ObjectResult)result).StatusCode.Should().Be((int)HttpStatusCode.Created);
        ((ObjectResult)result).Value.Should().BeEquivalentTo(id);
    }

    [Fact]
    public async Task UpdateOrganism_ShouldReturn_Ok()
    {
        // Arrange
        var id = Guid.NewGuid();

        var command = new UpdateOrganismCommand
        {
            Id = id,
            Name = "Consejo del Poder Judicial",
        };

        var cancelationToken = new CancellationToken();

        _mediatorMock.Setup(x => x.Send(command, cancelationToken)).ReturnsAsync(true);

        // Act
        var result = await _organismController.Update(command);

        // Assert

        ((ObjectResult)result).StatusCode.Should().Be((int)HttpStatusCode.OK);
        ((ObjectResult)result).Value.Should().BeEquivalentTo(true);
    }

    [Fact]
    public async Task DeleteOrganism_ShouldReturn_Ok()
    {
        // Arrange
        var id = Guid.NewGuid();

        var command = new DeleteOrganismCommand
        {
            Id = id
        };

        var cancelationToken = new CancellationToken();

        _mediatorMock.Setup(x => x.Send(command, cancelationToken)).ReturnsAsync(true);

        // Act
        var result = await _organismController.Delete(command);

        // Assert

        ((ObjectResult)result).StatusCode.Should().Be((int)HttpStatusCode.OK);
        ((ObjectResult)result).Value.Should().BeEquivalentTo(true);
    }
}
