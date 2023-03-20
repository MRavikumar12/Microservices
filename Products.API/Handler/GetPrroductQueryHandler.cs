using MediatR;
using Products.API.DataAccess;
using Products.API.Models;
using Products.API.Queries;

namespace Products.API.Handler
{
    public class GetPrroductQueryHandler:IRequestHandler<GetPrroductQuery,List<TProduct>>
    {
        private readonly IProduct _product;
        public GetPrroductQueryHandler(IProduct product)
        {
            _product = product;
        }

        public async Task<List<TProduct>> Handle(GetPrroductQuery request, CancellationToken cancellationToken)
        {
           return await Task.FromResult(_product.GetAllProducts());
        }
    }
}
