using System;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

using SimpleBE.Api.Controllers;
using SimpleBE.Application.Services;
using SimpleBE.Application.Dtos;
using SimpleBE.Domain.Enums;

namespace SimpleBE.UnitTests;

public class UserControllerTests
{
    private readonly Mock<IUserService> userServiceStub = new();
    private readonly Mock<ILogger<UserController>> loggingStub = new();

    [Fact]
    public async Task GetById_WithUnexistingItem_ReturnsNotFound()
    {
        // Arrange
        userServiceStub.Setup(service => service.FindById(It.IsAny<Guid>())).ReturnsAsync(null as UserDTO);
        var controller = new UserController(loggingStub.Object, userServiceStub.Object);

        // Act
        var result = await controller.GetById(Guid.NewGuid());

        // Assert
        result.Should().BeOfType<NotFoundResult>();
    }

    [Fact]
    public async Task GetById_WithExistingItem_ReturnsNotFound()
    {
        // Arrange
        var expectedUser = CreateRandomUser();
        userServiceStub.Setup(service => service.FindById(It.IsAny<Guid>())).ReturnsAsync(expectedUser);
        var controller = new UserController(loggingStub.Object, userServiceStub.Object);

        // Act
        var result = await controller.GetById(Guid.NewGuid()) as OkObjectResult;

        // Assert
        result?.Value.Should().BeEquivalentTo(expectedUser, options => options.ComparingByMembers<UserDTO>());
    }

    [Fact]
    public async Task Get_WithExistingItem_ReturnsAllUsers()
    {
        // Arrange
        var expectedUsers = new[] { CreateRandomUser(), CreateRandomUser(), CreateRandomUser() };
        userServiceStub.Setup(service => service.FindAll()).ReturnsAsync(expectedUsers);
        var controller = new UserController(loggingStub.Object, userServiceStub.Object);

        // Act
        var result = await controller.Get() as OkObjectResult;

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