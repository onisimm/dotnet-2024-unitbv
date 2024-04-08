using LabProject.Database.Context;
using LabProject.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabProject.Database.Repositories
{
    public class UserProjectsRepository : BaseRepository
    {
        public UserProjectsRepository(LabProjectDbContext labProjectDbContext) : base(labProjectDbContext)
        {
        }

        public void Add(UserProject userProject)
        {
            labProjectDbContext.UserProjects.Add(userProject);
            labProjectDbContext.SaveChanges();
        }
    }
}
