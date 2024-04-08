using LabProject.Database.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabProject.Database.Repositories
{
    public class ProjectsRepository : BaseRepository
    {
        public ProjectsRepository(LabProjectDbContext labProjectDbContext) : base(labProjectDbContext)
        {
        }
    }
}
