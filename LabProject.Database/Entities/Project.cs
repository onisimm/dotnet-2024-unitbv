using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabProject.Database.Entities
{
    public class Project : BaseEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }

        public List<UserProject> UserProjects { get; set; } 
        public List<Task> Tasks { get; set; } 
    }
}
