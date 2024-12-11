using AutoMapper;
using Microsoft.Extensions.Logging;

namespace ToDo.Tests;

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ToDo.Controllers;
using ToDo.Models;
using ToDo.Services;
using Xunit;

//Testing the Todos controller
public class ToDoControllerTests
{
    private readonly Mock<IToDoService> _toDoServiceMock;
    private readonly Mock<ILogger<ToDosController>> _loggerMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly ToDosController _controller;

    public ToDoControllerTests()
    {
        _toDoServiceMock = new Mock<IToDoService>();
        _loggerMock = new Mock<ILogger<ToDosController>>();
        _mapperMock = new Mock<IMapper>();
        _controller = new ToDosController( _loggerMock.Object, _mapperMock.Object, _toDoServiceMock.Object);
    }

    [Fact]
    public async Task GetToDoItems_ReturnsOkResultWithTodoResponses()
    {
        // Arrange
        var mockToDoResponses = new List<ToDoResponse>
        {
            new ToDoResponse { Id = 1, Todo = "Test ToDo 1", Completed = false },
            new ToDoResponse { Id = 2, Todo = "Test ToDo 2", Completed = true }
        };

        _toDoServiceMock
            .Setup(service => service.FetchToDoList())
            .ReturnsAsync(mockToDoResponses);

        //Act
        var result = await _controller.GetToDoItems();

        //Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnedToDos = Assert.IsType<List<ToDoResponse>>(okResult.Value);

        Assert.Equal(mockToDoResponses.Count, returnedToDos.Count);
        Assert.Equal(mockToDoResponses[0].Todo, returnedToDos[0].Todo);
        Assert.Equal(mockToDoResponses[1].Todo, returnedToDos[1].Todo);

        _toDoServiceMock.Verify(service => service.FetchToDoList(), Times.Once);
    }
}
