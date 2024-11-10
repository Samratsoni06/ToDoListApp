using ToDoListApp.Models;

namespace ToDoListApp.Repository
{
    public interface IToDoRepository
    {
        Task<List<TaskItem>> GetAllTask();
        Task<TaskItem> GetTaskById(Guid id);
        Task<TaskItem> CreateTask(TaskItem item);
        Task<TaskItem> UpdateTask(TaskItem task , Guid Id);
        Task<TaskItem> DeleteTaskById(Guid id);
    }
}
