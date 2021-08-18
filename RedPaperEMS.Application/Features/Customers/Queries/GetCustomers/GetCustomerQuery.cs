using MediatR;
using System.Collections.Generic;

namespace RedPaperEMS.Application.Features.Customers.Queries.GetCustomers
{
    public class GetCustomerQuery: IRequest<List<CustomerListVm>>
    {

    }
}
