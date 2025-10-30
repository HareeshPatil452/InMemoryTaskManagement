namespace InMemoryTaskManagement.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public string Category { get; set; } = string.Empty;
        public TaskPriority Priority { get; set; } = TaskPriority.Medium;
        public bool IsCompleted { get; set; } = false;
    }

    public enum TaskPriority
    {
        Low,
        Medium,
        High
    }
}
