using Xunit;
using TodoApp.Api.Models;

namespace TodoApp.Api.Tests
{
    public class TodoItemTests
    {
        [Fact]
        public void TodoItem_DefaultValues()
        {
            var item = new TodoItem();
            Assert.Equal(0, item.Id);
            Assert.Equal(string.Empty, item.Title);
            Assert.False(item.IsDone);
        }

        [Fact]
        public void TodoItem_SetProperties()
        {
            var item = new TodoItem { Id = 5, Title = "Test", IsDone = true };
            Assert.Equal(5, item.Id);
            Assert.Equal("Test", item.Title);
            Assert.True(item.IsDone);
        }
    }
}
