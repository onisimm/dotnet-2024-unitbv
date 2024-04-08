namespace LabProject.Database.Dtos.Request
{
    public class AddProjectRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
    }
}
