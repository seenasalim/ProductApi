using MediatR;

namespace Product.Application.Features.Orders.Commands.DeleteOrder
{
    public class DeleteProductCommand : IRequest
    {
        public int Id { get; set; }
    }
}
