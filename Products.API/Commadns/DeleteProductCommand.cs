using MediatR;

namespace Products.API.Commadns
{
    public record DeleteProductCommand(int id):IRequest<string>;
    
}
