﻿using LabProject.Database.Context;
using LabProject.Database.Entities;
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
    }
}
