using LabProject.Database.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabProject.Database.Dtos.Response
{
    public class GetTasksResponse
    {
        public List<TaskDto> Tasks { get; set; }
        public int Count { get; set; }
    }
}
