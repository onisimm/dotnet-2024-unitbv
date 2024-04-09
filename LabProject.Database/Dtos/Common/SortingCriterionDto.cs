using LabProject.Database.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabProject.Database.Dtos.Common
{
    public class SortingCriterionDto
    {
        public SortingOrder Order { get; set; } 
        public SortingCriterion Criterion { get; set; } 
    }
}
