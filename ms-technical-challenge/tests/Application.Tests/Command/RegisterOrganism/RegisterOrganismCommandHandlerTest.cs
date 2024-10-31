namespace Application.Tests.Command.RegisterPerson;
using System;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.EntityFrameworkCore.Storage;
using Moq;
using SB.TechnicalChallenge.Application;
using SB.TechnicalChallenge.Domain;
using SB.TechnicalChallenge.Infrastructure;

public class RegisterOrganismCommandHandlerTest
{
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly RegisterOrganismCommandHandler _createOrderCommandHandler;
    private readonly Mock<IDbContextTransaction> _contextTransactionMock;
    private readonly Mock<IExecutionStrategy> _contextStrategyMock;

    public RegisterOrganismCommandHandlerTest()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _createOrderCommandHandler = new RegisterOrganismCommandHandler(_unitOfWorkMock.Object);
        _contextTransactionMock = new Mock<IDbContextTransaction>();
        _contextStrategyMock = new Mock<IExecutionStrategy>();
    }

    [Fact]
    public async Task Handle_ShouldPassTrought_Command()
    {
        // Arrange
        var id = Guid.NewGuid();
        var person = new Person();
        person.Register("Angel", "Hinostroza", "tromepop@gmail.com");

        _unitOfWorkMock.Setup(m => m.Repository<Person>().Add(It.IsAny<Person>())).ReturnsAsync(It.IsAny<Person>());
        _unitOfWorkMock.Setup(m => m.SaveEntitiesAsync(new CancellationToken())).ReturnsAsync(It.IsAny<int>());
        _unitOfWorkMock.Setup(m => m.CreateExecutionStrategy()).Returns(_contextStrategyMock.Object);
        _unitOfWorkMock.Setup(m => m.BeginTransactionAsync()).ReturnsAsync(_contextTransactionMock.Object);


        var command = new RegisterOrganismCommand
        {
            Name = "Angel",
            LastName = "Hinostroza",
            Email = "tromepop@gmail.com"
        };

        //Act
        var result = await _createOrderCommandHandler.Handle(command, new CancellationToken());

        //Assert

        result.Should().NotBe(id);
    }
}
