using AutoMapper;
using MediatR;
using RedPaperEMS.Application.Contracts.Persistence;
using RedPaperEMS.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RedPaperEMS.Application.Features.Categories.Queries.GetCategoryList
{
    public class GetCategoriesListQueryHandler:IRequestHandler<GetCategoriesListQuery,List<CategoryListVm>>
    {
        private readonly IAsyncRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;
        public GetCategoriesListQueryHandler(IAsyncRepository<Category> categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<List<CategoryListVm>> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
        {
            var categories = (await _categoryRepository.ListAllAsync()).OrderBy(x => x.Name);
            return _mapper.Map<List<CategoryListVm>>(categories);
        }
    }
}
