using MediatR;
using Products.API.Models;

namespace Products.API.Commadns
{
    public record UpdateProductCommand(TProduct tProduct):IRequest<List<TProduct>>;
    
}
