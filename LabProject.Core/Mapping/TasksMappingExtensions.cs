using LabProject.Database.Dtos.Common;
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

        public static List<TaskDto> ToTaskDtos(this List<Task> entities)
        {
            var results = entities.Select(e => e.ToTaskDto()).ToList();

            return results;
        }

        private static TaskDto ToTaskDto(this Task entity)
        {
            if (entity == null) return null;

            var result = new TaskDto();
            result.Title = entity.Title;
            result.Description = entity.Description;
            result.StartDate = entity.StartDate;
            result.DueDate = entity.DueDate;
            result.Status = entity.Status;
            result.Priority = entity.Priority;
            result.ProjectTitle = entity.Project?.Title;

            result.AssignedUser = new UserShortDto();

            if (entity.AssignedUser == null)
                result.AssignedUser = null;
            else
            {
                result.AssignedUser.Id = entity.AssignedUser.Id;
                result.AssignedUser.FirstName = entity.AssignedUser.FirstName;
                result.AssignedUser.LastName = entity.AssignedUser.LastName;
            }

            return result;
        }
    }
}
