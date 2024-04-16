using LabProject.Database.Dtos.Common;
using LabProject.Database.Enums;

namespace LabProject.Database.Dtos.Response
{
    public class GetTaskDetailsResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public TaskStatuses Status { get; set; }
        public TaskPriorities Priority { get; set; }
        public string ProjectTitle { get; set; }
        public UserShortDto AssignedUser { get; set; }
    }
}
