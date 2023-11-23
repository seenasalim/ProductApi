using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Product.Application.Contracts.Infrastructure;
using Product.Application.Contracts.Persistence;
using Product.Application.Models;
using Product.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Product.Application.Features.Orders.Commands.CheckoutOrder
{
    public class CheckoutProductCommandHandler : IRequestHandler<CheckoutProductCommand, int>
    {
        private readonly IProductRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CheckoutProductCommandHandler> _logger;

        public CheckoutProductCommandHandler(IProductRepository orderRepository, IMapper mapper, ILogger<CheckoutProductCommandHandler> logger)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<int> Handle(CheckoutProductCommand request, CancellationToken cancellationToken)
        {
            var orderEntity = _mapper.Map<ProductModel>(request);
            await _orderRepository.CreateProduct(orderEntity);

            _logger.LogInformation($"Order {1} is successfully created.");
            return 1;
        }

 
    }
}
