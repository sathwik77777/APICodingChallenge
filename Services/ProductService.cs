using APIChallenge.Entities;
using APIChallenge.Database;
namespace APIChallenge.Services
{
    public class ProductService : IProductService
    {
        private readonly MyContext _context;

        public ProductService(MyContext context)
        {
            _context = context;
        }

        public void AddProduct(Product product) //Add Product 
        {
            try
            {
                _context.Products.Add(product);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteProduct(int productId)
        {
            try
            {
                
                Product product = _context.Products.SingleOrDefault(p => p.ProductId == productId);
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Product GetProductById(int productId)
        {
            try
            {
                
                Product? product = _context.Products.SingleOrDefault(p => p.ProductId == productId);
                return product;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Product> GetAllProducts()
        {
            try
            {
                return _context.Products.ToList(); 
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateProduct(Product product)
        {
            try
            {
                _context.Products.Update(product);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
