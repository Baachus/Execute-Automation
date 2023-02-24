namespace EAWebApp.Producer
{
    public class ProductUtil : IProductUtil
    {
        private readonly ProductAPI _productApiClient;

        public ProductUtil() => _productApiClient = new ProductAPI("http://eaapi:8001", new HttpClient());

        public async Task<Product> CreateProduct(Product product)
        {
            return await _productApiClient.AddProductAsync(product);
        }

        public async Task<ICollection<Product>> GetProduct()
        {
            return await _productApiClient.GetProductsAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _productApiClient.GetProductByIdAsync(id);
        }

        public async Task DeleteProduct(int id)
        {
            await _productApiClient.DeleteProductAsync(id);
        }

        public async Task<Product> EditProduct(Product product)
        {
            return await _productApiClient.UpdateProductAsync(product);
        }
    }
}
