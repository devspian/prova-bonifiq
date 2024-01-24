using ProvaPub.Enum;
using ProvaPub.Models;
using ProvaPub.Repository;

namespace ProvaPub.Services
{
    public class OrderService
    {
        protected readonly OrderRepository _repository;

        public OrderService(OrderRepository repository)
        {
            _repository = repository;
        }
        public async Task<Order> PayOrder(EnumMetodoPagamento paymentMethod, decimal paymentValue, int customerId)
        {

            return await _repository.PayOrder(paymentMethod, paymentValue, customerId);

        }
    }
}
