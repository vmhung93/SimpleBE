using System;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Moq;
using Xunit;

using SimpleBE.Api.Controllers;
using SimpleBE.Api.Dtos;
using SimpleBE.Api.Services;
using SimpleBE.Api.Commands;

namespace SimpleBE.UnitTests;

public class AuthControllerTests
{
    private readonly Mock<IAuthService> authServiceStub = new();
    private readonly Mock<ILogger<AuthController>> loggingStub = new();

    [Fact]
    public async Task SignUp_WithSignUpData_ReturnsOk()
    {
        // Arrange
        var signUpDto = new SignUpCommand()
        {
            UserName = Guid.NewGuid().ToString(),
            FirstName = Guid.NewGuid().ToString(),
            LastName = Guid.NewGuid().ToString(),
            Password = Guid.NewGuid().ToString()
        };

        var controller = new AuthController(loggingStub.Object, authServiceStub.Object);

        // Act
        var result = await controller.SignUp(signUpDto);

        // Assert
        result.Should().BeOfType<OkResult>();
    }
}