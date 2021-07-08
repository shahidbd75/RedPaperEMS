using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace RedPaperEMS.Application.Features.Categories.Queries.GetCategoryList
{
    public class GetCategoriesListQuery: IRequest<List<CategoryListVm>>
    {
    }
}
