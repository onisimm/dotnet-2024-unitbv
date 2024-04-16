using LabProject.Database.Context;
using LabProject.Database.Dtos.Request;
using LabProject.Database.Entities;
using LabProject.Database.QueryExtensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
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

        private IQueryable<Task> GetTasksQuery(GetTasksRequest payload)
        {
            var query = labProjectDbContext.Tasks
                .Include(e => e.Project)
                .Include(e => e.AssignedUser)

                .Where(e => e.DateDeleted == null)
                .WhereStatus(payload)
                .WherePriority(payload)
                .WhereAssignedUserIds(payload)
                .WhereDateRange(payload);

            return query;

        }

        public List<Task> GetTasks(GetTasksRequest payload)
        {
            var results = GetTasksQuery(payload)
                .Sort(payload.SortingCriterion)

                .AsNoTracking()
                .ToList();

            return results; 
        }

        public int CountTasks(GetTasksRequest payload)
        {
            var count = GetTasksQuery(payload)
                .Count();

            return count;
        }

        public Task GetById(int taskId)
        {
            var result = labProjectDbContext.Tasks
                .Include(e => e.Project)
                .Include(e => e.AssignedUser)

                .Where(e => e.Id == taskId)
                .Where(e => e.DateDeleted == null)

                .FirstOrDefault();

            return result;
        }

        public void EditTask(Task task, EditTaskRequest payload)
        {
            task.Title = payload.Title;
            task.Description = payload.Description;
            task.Status = payload.Status;
            task.Priority = payload.Priority;
            task.StartDate = payload.StartDate;
            task.DueDate = payload.DueDate;
            task.ProjectId = payload.ProjectId;
            task.AssignedUserId = payload.AssignedUserId;

            if (labProjectDbContext.Entry(task).State == EntityState.Modified)
                task.DateUpdated = DateTime.UtcNow;

            SaveChanges();
        }

        public void DeleteTask(Task task)
        {
            task.DateDeleted = DateTime.UtcNow;
            SaveChanges();
        }
    }
}
