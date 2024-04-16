using LabProject.Database.Dtos.Common;
using LabProject.Database.Dtos.Request;
using LabProject.Database.Enums;
using Task = LabProject.Database.Entities.Task;

namespace LabProject.Database.QueryExtensions
{
    public static class TasksQueryExtensions
    {
        public static IQueryable<Task> WhereStatus(this IQueryable<Task> query, GetTasksRequest payload)
        {
            if (payload.Status == null)
                return query;

            query = query.Where(e => e.Status == payload.Status);

            return query;
        }

        public static IQueryable<Task> WherePriority(this IQueryable<Task> query, GetTasksRequest payload)
        {
            if (payload.Priority == null)
                return query;

            query = query.Where(e => e.Priority == payload.Priority);

            return query;
        }

        public static IQueryable<Task> WhereAssignedUserIds(this IQueryable<Task> query, GetTasksRequest payload)
        {
            if (payload.AssignedUserIds == null || payload.AssignedUserIds.Count == 0)
                return query;

            query = query.Where(e => payload.AssignedUserIds.Contains(e.AssignedUserId));

            return query;
        }

        public static IQueryable<Task> WhereDateRange(this IQueryable<Task> query, GetTasksRequest payload)
        {
            if (payload.DateRange == null)
                return query;

            query = query.Where(e => e.StartDate >= payload.DateRange.StartDate)
                         .Where(e => e.DueDate <= payload.DateRange.DueDate);

            return query;
        }

        public static IQueryable<Task> Sort(this IQueryable<Task> query, SortingCriterionDto sortingCriterion)
        {
            if (sortingCriterion == null)
                return query.OrderBy(e => e.DateCreated);

            switch (sortingCriterion.Criterion)
            {
                case SortingCriterion.ByStatus:
                    {
                        if (sortingCriterion.Order == SortingOrder.Ascending)
                            return query.OrderBy(e => e.Status);
                        else
                            return query.OrderByDescending(e => e.Status);
                    }

                case SortingCriterion.ByPriority:
                    {
                        if (sortingCriterion.Order == SortingOrder.Ascending)
                            return query.OrderBy(e => e.Priority);
                        else
                            return query.OrderByDescending(e => e.Priority);
                    }

                case SortingCriterion.ByStartDate:
                    {
                        if (sortingCriterion.Order == SortingOrder.Ascending)
                            return query.OrderBy(e => e.StartDate);
                        else
                            return query.OrderByDescending(e => e.StartDate);
                    }

                    default : return query;
            }
        }
    }
}
