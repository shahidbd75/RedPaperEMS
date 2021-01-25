using System.Collections.Generic;
using RedPaperEMS.Domain.Common;

namespace RedPaperEMS.Domain.Entities
{
    public class Category: AuditableEntity
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}