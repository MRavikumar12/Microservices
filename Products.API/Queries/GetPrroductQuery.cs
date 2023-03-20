using MediatR;
using Products.API.Models;

namespace Products.API.Queries
{
    public record GetPrroductQuery:IRequest<List<TProduct>>;


}
