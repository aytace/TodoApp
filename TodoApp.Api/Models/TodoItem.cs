
namespace TodoApp.Api.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsDone { get; set; }
        // Intentional issue: unused variable
        private int unusedField = 42;
        // Intentional issue: poor naming
        public string t { get; set; }
    }
}
