using MediatR;
using Products.API.Models;

namespace Products.API.Commadns
{
    public record AddProductCommand(TProduct tProduct):IRequest<List<TProduct>>;
    
}
