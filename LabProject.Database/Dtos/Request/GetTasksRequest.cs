using LabProject.Database.Dtos.Common;
using LabProject.Database.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabProject.Database.Dtos.Request
{
    public class GetTasksRequest
    {
        public SortingCriterionDto SortingCriterion { get; set; }

        public List<int?> AssignedUserIds { get; set; }
        public TaskStatuses Status { get; set; }
    }
}
