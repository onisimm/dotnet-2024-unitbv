using LabProject.Database.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabProject.Database.Dtos.Common
{
    public class TaskDto
    {
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
