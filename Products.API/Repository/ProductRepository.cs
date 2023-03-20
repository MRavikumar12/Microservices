using Products.API.DataAccess;
using Products.API.Models;

namespace Products.API.Repository
{
    public class ProductRepository:IProduct
    {
        private readonly MicroDb1Context _context;
        public ProductRepository(MicroDb1Context context)
        {
            _context = context;
        }

        public List<TProduct> AddNewProduct(TProduct tProduct)
        {
            _context.TProducts.Add(tProduct);
            _context.SaveChanges();
            return _context.TProducts.ToList();
        }

        public string DeleteProduct(int id)
        {
            var product = _context.TProducts.Find(id);
            if (product != null)
            {
                _context.TProducts.Remove(product);
                _context.SaveChanges();
                return "delete success";
            }
            else
            {
                return "product not found";
            }
        }

        
        public List<TProduct> GetAllProducts()
        {
            return _context.TProducts.ToList();
        }

        public List<TProduct> UpdateProduct(TProduct tProduct)
        {
            var prod = _context.TProducts.Find(tProduct.ProdId);
            if (prod != null)
            {
                _context.TProducts.Update(prod);
                _context.SaveChanges();
            }
                return _context.TProducts.ToList(); 
        }
    }
}
