using Products.API.Models;

namespace Products.API.DataAccess
{
    public interface IProduct
    {
        List<TProduct>GetAllProducts();
        public List<TProduct> AddNewProduct(TProduct tProduct);
        public List<TProduct>UpdateProduct(TProduct tProduct);
        public string DeleteProduct(int id);
    }
}
