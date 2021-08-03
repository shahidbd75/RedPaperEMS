using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedPaperEMS.Application.Features.Categories.Commands.CreateCategory;
using RedPaperEMS.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using RedPaperEMS.Application.Features.Categories.Queries.GetCategoryList;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RedPaperEMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all",Name = "GetAllCategories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CategoryListVm>>> GetAllCategories()
        {
            var categoryListVms = await _mediator.Send(new GetCategoriesListQuery());
            return Ok(categoryListVms);
        }

        [HttpGet("allWithEvents", Name = "GetCategoriesWithEvents")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<CategoryEventListVm>>> GetCategoriesWithEvents(bool includeHistory)
        {
            GetCategoriesListWithEventsQuery getCategoriesListWithEventsQuery = new GetCategoriesListWithEventsQuery()
            {
                IncludeHistory = includeHistory
            };
            var dtos = await _mediator.Send(getCategoriesListWithEventsQuery);
            return Ok(dtos);
        }

        [HttpPost("addCategory")]
        public async Task<ActionResult<CreateCategoryCommandResponse>> Create([FromBody] CreateCategoryCommand createCategoryCommand)
        {
            var response = await _mediator.Send(createCategoryCommand);
            return Ok(response);
        }
    }
}
