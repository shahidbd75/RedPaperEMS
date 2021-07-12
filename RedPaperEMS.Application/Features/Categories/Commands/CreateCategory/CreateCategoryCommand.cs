using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace RedPaperEMS.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand: IRequest<CreateCategoryCommandResponse>
    {
        public string Name { get; set; }
    }
}
