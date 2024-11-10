using Microsoft.EntityFrameworkCore;
using ToDoListApp.Data;
using ToDoListApp.Models;

namespace ToDoListApp.Repository
{
    public class SqlToDoRepository : IToDoRepository
    {
        protected ApplicationDbContext dbContext;

        public SqlToDoRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<TaskItem> CreateTask(TaskItem item)
        {
            try
            {
                await dbContext.TaskItems.AddAsync(item);
                await dbContext.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<TaskItem> DeleteTaskById(Guid id)
        {
            var ExistingRegion = await dbContext.TaskItems.FirstOrDefaultAsync(x => x.Id == id);
            if (ExistingRegion == null)
            {
                return null;
            }
            dbContext.TaskItems.Remove(ExistingRegion);
            await dbContext.SaveChangesAsync();
            return ExistingRegion;

        }

        public async Task<List<TaskItem>> GetAllTask()
        {
            return await dbContext.TaskItems.ToListAsync();
        }

        public async Task<TaskItem> GetTaskById(Guid Id)
        {
            var res = await dbContext.TaskItems.FirstOrDefaultAsync(x => x.Id == Id);
            return res;
        }

        public async Task<TaskItem> UpdateTask(TaskItem task, Guid Id)
        {
            try
            {
                var existingTask = await dbContext.TaskItems.FirstOrDefaultAsync(x => x.Id == Id);
                if (existingTask == null)
                {
                    return null;
                }
                existingTask.Title = task.Title;
                existingTask.Description = task.Description;
                existingTask.DueDate = task.DueDate;
                existingTask.IsCompleted = task.IsCompleted;

                await dbContext.SaveChangesAsync();
                return existingTask;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
