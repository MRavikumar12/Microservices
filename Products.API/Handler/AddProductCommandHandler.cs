using MediatR;
using Products.API.Commadns;
using Products.API.DataAccess;
using Products.API.Models;

namespace Products.API.Handler
{
    public class AddProductCommandHandler:IRequestHandler<AddProductCommand,List<TProduct>>
    {
        private readonly IProduct _product;
        public AddProductCommandHandler(IProduct product)
        {
            _product = product;
        }

        public async Task<List<TProduct>> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_product.AddNewProduct(request.tProduct));
        }
    }
}
