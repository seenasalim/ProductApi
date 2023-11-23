﻿using MediatR;

namespace Product.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateProductCommand : IRequest
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
        public decimal Price { get; set; }
        public int Id { get; set; }

    }
}
