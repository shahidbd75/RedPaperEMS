using MediatR;
using RedPaperEMS.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using RedPaperEMS.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;

namespace RedPaperEMS.Application.Features.Customers.Queries.GetCustomers
{
    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, List<CustomerListVm>>
    {
        private readonly IAsyncRepository<Customer> asyncRepository;
        readonly IMapper mapper;

        public GetCustomerQueryHandler(IAsyncRepository<Customer> asyncRepository, IMapper mapper)
        {
            this.asyncRepository = asyncRepository;
            this.mapper = mapper;
        }

        public async Task<List<CustomerListVm>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var allCustomer = await this.asyncRepository.ListAllAsync();

            return mapper.Map<List<CustomerListVm>>(allCustomer);
        }
    }
}
