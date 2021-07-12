using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedPaperEMS.Application.Contracts.Persistence;
using RedPaperEMS.Domain.Entities;

namespace RedPaperEMS.Persistence.Repositories
{
    public class EventRepository: BaseRepository<Event>,IEventRepository
    {
        public EventRepository(RedPaperDbContext dbContext) : base(dbContext)
        {
        }

        public Task<bool> IsEventNameAndDateUnique(string name, DateTime eventDate)
        {
            var matches = _dbContext.Events.Any(e => e.Name.Equals(name) && e.Date.Equals(eventDate));

            return Task.FromResult(matches);
        }
    }
}
