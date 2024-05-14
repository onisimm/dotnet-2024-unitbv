namespace LabProject.Database.Entities
{
    public class User : BaseEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }

        public List<Task> Tasks { get; set; }
        public List<UserProject> UserProjects { get; set; }
    }
}
