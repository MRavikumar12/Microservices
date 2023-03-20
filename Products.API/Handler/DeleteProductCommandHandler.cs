using MediatR;
using Products.API.Commadns;
using Products.API.DataAccess;

namespace Products.API.Handler
{
    public class DeleteProductCommandHandler:IRequestHandler<DeleteProductCommand,string>
    {
        private readonly IProduct _product;
        public DeleteProductCommandHandler(IProduct product)
        {
            _product = product;
        }

        public async Task<string> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
           return await Task.FromResult(_product.DeleteProduct(request.id));
        }
    }
}
