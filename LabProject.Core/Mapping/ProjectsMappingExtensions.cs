using LabProject.Database.Dtos.Request;
using LabProject.Database.Entities;

namespace LabProject.Core.Mapping
{
    public static class ProjectsMappingExtensions
    {
        public static Project ToEntity(this AddProjectRequest dto)
        {
            if (dto == null) return null;

            var result = new Project();
            result.Title = dto.Title;
            result.Description = dto.Description;
            result.StartDate = dto.StartDate;
            result.DueDate = dto.DueDate;

            result.DateCreated = DateTime.UtcNow;
            result.DateUpdated = DateTime.UtcNow;

            return result;
        }
    }
}
