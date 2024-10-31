namespace Application.Tests.Command.RegisterPerson;
using FluentValidation.TestHelper;
using SB.TechnicalChallenge.Application;
using SB.TechnicalChallenge.Application.Commands.Person.RegisterPerson;

public class RegisterOrganismCommandValidationTest
{
    private static readonly RegisterOrganismCommandValidation _validator = new();

    [Fact]
    public void Validator_ShouldNotHaveValidationErrorFor_Name()
    {
        // Arrange
        var command = new RegisterOrganismCommand
        {
            Name = "Senado de la República Dominicana"
        };

        // Act
        var result = _validator.TestValidate(command);

        // Assert
        result.ShouldNotHaveValidationErrorFor(command => command.Name);
    }

    [Fact]
    public void Validator_ShouldHaveValidationErrorFor_Name()
    {
        // Arrange
        var command = new RegisterOrganismCommand();

        // Act
        var result = _validator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(command => command.Name);
    }
}
