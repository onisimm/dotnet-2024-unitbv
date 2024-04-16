using LabProject.Database.Dtos.Common;
using LabProject.Database.Enums;

namespace LabProject.Database.Dtos.Request
{
    public class EditTaskRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public TaskStatuses Status { get; set; }
        public TaskPriorities Priority { get; set; }
        public int ProjectId { get; set; }
        public int? AssignedUserId { get; set; }
    }
}
