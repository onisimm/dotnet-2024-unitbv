using LabProject.Database.Context;

namespace LabProject.Database.Repositories
{
    public class UsersRepository : BaseRepository
    {
        public UsersRepository(LabProjectDbContext labProjectDbContext) : base(labProjectDbContext)
        {
        }
    }
}
