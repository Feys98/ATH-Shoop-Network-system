

using ATH_Shoop_Network_system_Server.Repository.Interfaces;

namespace ATH_Shoop_Network_system_Server.Services
{
    internal class ProductService
    {
        IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Shop>> GetAll()
        {
            return (await _productRepository.GetShops()).ToList();
        }

        public async Task<Shop> GetById(int id)
        {
            return (await _productRepository.GetShop(id));
        }
    }
}
