using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RedPaperEMS.Application.Contracts.Persistence;
using RedPaperEMS.Domain.Entities;

namespace RedPaperEMS.Persistence.Repositories
{
    public class CategoryRepository: BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(RedPaperDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Category>> GetCategoriesWithEvents(bool includePassedEvents)
        {
            var allCategories = await _dbContext.Categories.Include(x => x.Events).ToListAsync();
            if (!includePassedEvents)
            {
                allCategories.ForEach(c=>c.Events.ToList().RemoveAll(c=>c.Date < DateTime.Today));
            }

            return allCategories;
        }
    }
}
