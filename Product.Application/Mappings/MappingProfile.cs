using AutoMapper;
using Product.Application.Features.Orders.Commands.CheckoutOrder;
using Product.Application.Features.Orders.Commands.UpdateOrder;
using Product.Application.Features.Orders.Queries.GetOrdersList;
using Product.domain.Entities;

namespace Product.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductModel, OrdersVm>().ReverseMap();
            CreateMap<ProductModel, CheckoutProductCommand>().ReverseMap();
            CreateMap<ProductModel, UpdateProductCommand>().ReverseMap();
        }
    }
}
