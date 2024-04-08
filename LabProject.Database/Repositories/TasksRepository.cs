using LabProject.Database.Context;
using Task = LabProject.Database.Entities.Task;

namespace LabProject.Database.Repositories
{
    public class TasksRepository : BaseRepository
    {
        public TasksRepository(LabProjectDbContext labProjectDbContext) : base(labProjectDbContext)
        {
        }
    }
}
