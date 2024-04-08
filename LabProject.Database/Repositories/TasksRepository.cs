using LabProject.Database.Context;
using LabProject.Database.Entities;
using Task = LabProject.Database.Entities.Task;

namespace LabProject.Database.Repositories
{
    public class TasksRepository : BaseRepository
    {
        public TasksRepository(LabProjectDbContext labProjectDbContext) : base(labProjectDbContext)
        {
        }

        public void Add(Task task)
        {
            labProjectDbContext.Tasks.Add(task);
            labProjectDbContext.SaveChanges();
        }

        public void AddRange(List<Task> tasks)
        {
            labProjectDbContext.Tasks.AddRange(tasks);
            labProjectDbContext.SaveChanges();
        }
    }
}
