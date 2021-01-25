using RedPaperEMS.Domain.Entities;

namespace RedPaperEMS.Application.Contracts.Persistence
{
    interface IEventRepository : IAsyncRepository<Event>
    {
    }
}