using System.Collections.Generic;
using TaskModel = InMemoryTaskManagement.Models.Task;

namespace InMemoryTaskManagement.Services
{
    public interface ITaskService
    {
        List<TaskModel> GetAll();
        TaskModel? GetById(int id);
        void Add(TaskModel task);
        void Update(TaskModel task);
        void Delete(int id);
    }
}
