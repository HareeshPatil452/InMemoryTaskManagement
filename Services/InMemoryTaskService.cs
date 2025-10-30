using System.Collections.Generic;
using System.Linq;
using TaskModel = InMemoryTaskManagement.Models.Task;

namespace InMemoryTaskManagement.Services
{
    public class InMemoryTaskService : ITaskService
    {
        private readonly List<TaskModel> tasks = new();
        private int nextId = 1;

        public List<TaskModel> GetAll() => tasks;

        public TaskModel? GetById(int id) => tasks.FirstOrDefault(t => t.Id == id);

        public void Add(TaskModel task)
        {
            task.Id = nextId++;
            tasks.Add(task);
        }

        public void Update(TaskModel task)
        {
            var existing = GetById(task.Id);
            if (existing != null)
            {
                existing.Title = task.Title;
                existing.Description = task.Description;
                existing.DueDate = task.DueDate;
                existing.Category = task.Category;
                existing.Priority = task.Priority;
                existing.IsCompleted = task.IsCompleted;
            }
        }

        public void Delete(int id)
        {
            var task = GetById(id);
            if (task != null)
            {
                tasks.Remove(task);
            }
        }
    }
}
