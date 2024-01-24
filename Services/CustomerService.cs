using Microsoft.EntityFrameworkCore;
using ProvaPub.Models;
using ProvaPub.Repository;

namespace ProvaPub.Services
{
    public class CustomerService
    {
        CustomerRepository _repository;

        public CustomerService(CustomerRepository repository)
        {
            _repository = repository;
        }

        public CustomerList ListCustomers(int page)
        {
            return _repository.ListCustomers(page);
        }

        public async Task<bool> CanPurchase(int customerId, decimal purchaseValue)
        {
          return await _repository.CanPurchase(customerId, purchaseValue);
        }

    }
}
