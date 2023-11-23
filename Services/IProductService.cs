using APIChallenge.Entities;

namespace APIChallenge.Services
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        void AddProduct(Product product);
        Product GetProductById(int productId);
        void UpdateProduct(Product product);
        public abstract void DeleteProduct(int productId);


    }
}
