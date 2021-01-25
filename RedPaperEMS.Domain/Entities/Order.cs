using System;
using System.Collections.Generic;
using System.Text;
using RedPaperEMS.Domain.Common;

namespace RedPaperEMS.Domain.Entities
{
    public class Order: AuditableEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public double OrderTotal { get; set; }
        public DateTime OrderPlaced { get; set; }
        public bool OrderPaid { get; set; }
    }
}
