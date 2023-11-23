using AutoMapper;
using MediatR;
using Product.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Product.Application.Features.Orders.Queries.GetOrdersList
{
    public class GetOrdersListQueryHandler : IRequestHandler<GetOrdersListQuery, List<OrdersVm>>
    {
        private readonly IProductRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrdersListQueryHandler(IProductRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<OrdersVm>> Handle(GetOrdersListQuery request, 
            CancellationToken cancellationToken)
        {
            var orderList = await _orderRepository.GetProductByName(request.UserName);
            return _mapper.Map<List<OrdersVm>>(orderList);
        }
    }
}
