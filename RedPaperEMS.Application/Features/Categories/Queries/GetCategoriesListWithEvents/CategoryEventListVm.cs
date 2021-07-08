using System;
using System.Collections.Generic;
using System.Text;

namespace RedPaperEMS.Application.Features.Categories.Queries.GetCategoriesListWithEvents
{
    public class CategoryEventListVm
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }

        public  ICollection<CategoryEventDto> Events { get; set; }
    }
}
