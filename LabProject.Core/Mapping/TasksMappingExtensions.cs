using LabProject.Database.Dtos.Request;
using LabProject.Database.Entities;
using Task = LabProject.Database.Entities.Task;

namespace LabProject.Core.Mapping
{
    public static class TasksMappingExtensions
    {
        public static List<Task> ToEntities(this List<AddTaskRequest> dtos)
        {
            var results = dtos.Select(e => e.ToEntity()).ToList();   

            return results;
        }

        public static Task ToEntity(this AddTaskRequest dto)
        {
            if (dto == null) return null;

            var result = new Task();
            result.Title = dto.Title;
            result.Description = dto.Description;
            result.StartDate = dto.StartDate;
            result.DueDate = dto.DueDate;
            result.Status = dto.Status;
            result.Priority = dto.Priority;
            result.ProjectId = dto.ProjectId;
            result.AssignedUserId = dto.AssignedUserId;

            result.DateCreated = DateTime.UtcNow;
            result.DateUpdated = DateTime.UtcNow;

            return result;
        }
    }
}
