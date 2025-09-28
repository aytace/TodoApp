using Xunit;
using TodoApp.Api.Controllers;
using TodoApp.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TodoApp.Api.Tests
{
    public class TodoControllerTests
    {
        [Fact]
        public void Get_ReturnsAllTodos()
        {
            var controller = new TodoController();
            var result = controller.Get();
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<TodoItem>>(result);
        }

        [Fact]
        public void Post_AddsTodoItem()
        {
            var controller = new TodoController();
            var newItem = new TodoItem { Title = "New", IsDone = false };
            var result = controller.Post(newItem) as OkObjectResult;
            Assert.NotNull(result);
            var item = Assert.IsType<TodoItem>(result.Value);
            Assert.Equal("New", item.Title);
        }

        [Fact]
        public void Put_UpdatesTodoItem()
        {
            var controller = new TodoController();
            var newItem = new TodoItem { Title = "Update", IsDone = false };
            var postResult = controller.Post(newItem) as OkObjectResult;
            var item = Assert.IsType<TodoItem>(postResult.Value);
            item.IsDone = true;
            var putResult = controller.Put(item.Id, item) as OkObjectResult;
            Assert.NotNull(putResult);
            var updated = Assert.IsType<TodoItem>(putResult.Value);
            Assert.True(updated.IsDone);
        }

        [Fact]
        public void Delete_RemovesTodoItem()
        {
            var controller = new TodoController();
            var newItem = new TodoItem { Title = "Delete", IsDone = false };
            var postResult = controller.Post(newItem) as OkObjectResult;
            var item = Assert.IsType<TodoItem>(postResult.Value);
            var deleteResult = controller.Delete(item.Id);
            Assert.IsType<NoContentResult>(deleteResult);
        }

        [Fact]
        public void Post_NullItem_ReturnsBadRequest()
        {
            var controller = new TodoController();
            var result = controller.Post(null);
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void Put_NonExistentId_ReturnsNotFound()
        {
            var controller = new TodoController();
            var result = controller.Put(999, new TodoItem { Title = "X", IsDone = false });
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Delete_NonExistentId_ReturnsNotFound()
        {
            var controller = new TodoController();
            var result = controller.Delete(999);
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
