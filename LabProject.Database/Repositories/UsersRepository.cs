using LabProject.Database.Context;
using LabProject.Database.Entities;
using LabProject.Infrastructure.Exceptions;

namespace LabProject.Database.Repositories
{
    public class UsersRepository : BaseRepository
    {
        public UsersRepository(LabProjectDbContext labProjectDbContext) : base(labProjectDbContext)
        {
        }

        public void Add(User user)
        {
            labProjectDbContext.Users.Add(user);
            labProjectDbContext.SaveChanges();
        }

        public User GetByEmail(string email)
        {
            var result = labProjectDbContext.Users

                .Where(e => e.Email == email)
                .Where(e => e.DateDeleted == null)

                .FirstOrDefault();

            if (result == null)
                throw new ResourceMissingException("User not found");

            return result;
        }

        public bool ValidateUserId(int userId)
        {
            var result = labProjectDbContext.Users
                .Where(e => e.Id == userId)
                .Where(e => e.DateDeleted == null)

                .Any();

            return result;
        }
    }
}
