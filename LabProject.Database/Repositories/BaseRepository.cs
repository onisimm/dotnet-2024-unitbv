using LabProject.Database.Context;

namespace LabProject.Database.Repositories
{
    public class BaseRepository
    {
        protected LabProjectDbContext labProjectDbContext { get; set; }

        public BaseRepository(LabProjectDbContext labProjectDbContext)
        {
            this.labProjectDbContext = labProjectDbContext;
        }

        public void SaveChanges()
        {
            labProjectDbContext.SaveChanges();
        }
    }
}
