﻿using System;
using System.Text;
using RedPaperEMS.Domain.Common;

namespace RedPaperEMS.Domain.Entities
{
    public class Event: AuditableEntity
    {
        public Guid EventId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Artist { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
