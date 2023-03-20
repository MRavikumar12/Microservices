using MediatR;
using Products.API.Commadns;
using Products.API.DataAccess;
using Products.API.Models;

namespace Products.API.Handler
{
    public class UpdateProductCommandHandler:IRequestHandler<UpdateProductCommand,List<TProduct>>
    {
        private readonly IProduct _product;
        public UpdateProductCommandHandler(IProduct product)
        {
            _product = product;
        }

        public async Task<List<TProduct>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_product.UpdateProduct(request.tProduct));
        }
    }
}
