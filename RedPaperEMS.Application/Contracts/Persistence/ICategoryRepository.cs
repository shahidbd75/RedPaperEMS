using System;
using RedPaperEMS.Domain.Entities;

namespace RedPaperEMS.Application.Contracts.Persistence
{
    interface ICategoryRepository: IAsyncRepository<Category>
    {
    }
}
