using System;
using System.Threading.Tasks;
using RedPaperEMS.Domain.Entities;

namespace RedPaperEMS.Application.Contracts.Persistence
{
    public interface IEventRepository : IAsyncRepository<Event>
    {
        Task<bool> IsEventNameAndDateUnique(string name, DateTime eventDate);
    }
}