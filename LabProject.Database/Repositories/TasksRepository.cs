using LabProject.Database.Context;
using LabProject.Database.Dtos.Request;
using LabProject.Database.Entities;
using Microsoft.EntityFrameworkCore;
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

        public List<Task> GetTasks(GetTasksRequest payload)
        {
            var results = labProjectDbContext.Tasks
                .Include(e => e.Project)
                .Include(e => e.AssignedUser)
              
                .Where(e => e.DateDeleted == null)
                .Where(e => e.Status == payload.Status)
                .Where(e => payload.AssignedUserIds.Contains(e.AssignedUserId))

                .OrderBy(e => e.StartDate)
                .ThenBy(e => e.DueDate)

                .AsNoTracking()
                .ToList();

            return results; 
        }

        public int CountTasks(GetTasksRequest payload)
        {
            var count = labProjectDbContext.Tasks
                .Where(e => e.DateDeleted == null)
                .Where(e => e.Status == payload.Status)
                .Where(e => payload.AssignedUserIds.Contains(e.AssignedUserId))

                .Count();

            return count;
        }
    }
}
