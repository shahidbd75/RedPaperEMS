using RedPaperEMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedPaperEMS.Application.Contracts.Persistence
{
    public interface ICustomerRepository : IAsyncRepository<Customer>
    {
    }
}
