
namespace TodoApp.Api.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public bool IsDone { get; set; }
        // Intentional issue: unused variable
        private int unusedField = 42;
    }
}
