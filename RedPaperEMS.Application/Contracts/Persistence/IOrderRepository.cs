using RedPaperEMS.Domain.Entities;

namespace RedPaperEMS.Application.Contracts.Persistence
{
    interface IOrderRepository : IAsyncRepository<Order>
    {
    }
}