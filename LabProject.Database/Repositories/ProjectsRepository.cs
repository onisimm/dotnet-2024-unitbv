using LabProject.Database.Context;
using LabProject.Database.Entities;
using LabProject.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;
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

        public void Add(Project project)
        {
            labProjectDbContext.Projects.Add(project);
            labProjectDbContext.SaveChanges();
        }

        public bool ValidateProjectId(int projectId)
        {
            var result = labProjectDbContext.Projects
                .Where(e => e.Id == projectId)
                .Where(e => e.DateDeleted == null)

                .Any();

            return result;
        }
    }
}
