using System;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

using SimpleBE.Api.Controllers;
using SimpleBE.Api.Dtos;
using SimpleBE.Api.Enums;
using SimpleBE.Api.Services;

namespace SimpleBE.UnitTests;

public class UserControllerTests
{
    private readonly Mock<IUserService> userServiceStub = new();
    private readonly Mock<ILogger<UserController>> loggingStub = new();

    [Fact]
    public void GetById_WithUnexistingItem_ReturnsNotFound()
    {
        // Arrange
        userServiceStub.Setup(service => service.FindById(It.IsAny<Guid>())).Returns((UserDTO)null);
        var controller = new UserController(loggingStub.Object, userServiceStub.Object);

        // Act
        var result = controller.GetById(Guid.NewGuid());

        // Assert
        result.Should().BeOfType<NotFoundResult>();
    }

    [Fact]
    public void GetById_WithExistingItem_ReturnsNotFound()
    {
        // Arrange
        var expectedUser = CreateRandomUser();
        userServiceStub.Setup(service => service.FindById(It.IsAny<Guid>())).Returns(expectedUser);
        var controller = new UserController(loggingStub.Object, userServiceStub.Object);

        // Act
        var result = controller.GetById(Guid.NewGuid()) as OkObjectResult;

        // Assert
        result?.Value.Should().BeEquivalentTo(expectedUser, options => options.ComparingByMembers<UserDTO>());
    }

    [Fact]
    public void Get_WithExistingItem_ReturnsAllUsers()
    {
        // Arrange
        var expectedUsers = new[] { CreateRandomUser(), CreateRandomUser(), CreateRandomUser() };
        userServiceStub.Setup(service => service.FindAll()).Returns(expectedUsers);
        var controller = new UserController(loggingStub.Object, userServiceStub.Object);

        // Act
        var result = controller.Get() as OkObjectResult;

        // Assert
        result?.Value.Should().BeEquivalentTo(expectedUsers, options => options.ComparingByMembers<UserDTO>());
    }

    private UserDTO CreateRandomUser()
    {
        return new UserDTO()
        {
            Id = Guid.NewGuid(),
            FirstName = Guid.NewGuid().ToString(),
            LastName = Guid.NewGuid().ToString(),
            UserName = Guid.NewGuid().ToString(),
            Role = Role.User,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
    }
}