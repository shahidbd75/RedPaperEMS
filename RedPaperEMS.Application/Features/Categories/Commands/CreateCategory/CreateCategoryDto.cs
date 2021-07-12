using System;

namespace RedPaperEMS.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}