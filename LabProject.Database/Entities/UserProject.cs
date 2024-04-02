using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabProject.Database.Entities
{
    public class UserProject : BaseEntity
    {
        public int UserId { get; set; } 
        public int ProjectId { get; set; } 

        public User User { get; set; }
        public Project Project { get; set; }
    }
}
