using ProvaPub.Models;
using ProvaPub.Repository;

namespace ProvaPub.Services
{
    public class ProductService 
    {
        ProductRepository _repository;

        public ProductService(ProductRepository repository)
        {
            _repository = repository;
        }

        public ProductList ListProducts(int page)
        {
            return _repository.List(page);
        }

    }
}
