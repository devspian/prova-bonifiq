using ProvaPub.Enum;
using ProvaPub.Models;

namespace ProvaPub.Repository
{
    public class OrderRepository
    {
        protected readonly TestDbContext _ctx;
        private static int lastOrderId = 0;
        public OrderRepository(TestDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<Order> PayOrder(EnumMetodoPagamento paymentMethod, decimal paymentValue, int customerId)
        {
           
            if (paymentMethod == EnumMetodoPagamento.pix)
                return await PayOrderPix(paymentValue, customerId);

            if (paymentMethod == EnumMetodoPagamento.creditcard)
                return await PayOrderCreditCard(paymentValue, customerId);

            if (paymentMethod == EnumMetodoPagamento.paypal)
                return await PayOrderPaypal(paymentValue, customerId);

            throw new Exception("Falha ao locazalizar paymentMethod");

        }

        public async Task<Order> PayOrderPix(decimal paymentValue, int customerId)
        {
            //Faz pagamento...

            return await Task.FromResult(new Order()
            {
                Id = Interlocked.Increment(ref lastOrderId),
                Value = paymentValue,
                CustomerId = customerId,
                OrderDate = DateTime.Now,
                Customer = GetCustomer(customerId)
            });
        }
        public async Task<Order> PayOrderCreditCard(decimal paymentValue, int customerId)
        {
            //Faz pagamento...

            return await Task.FromResult(new Order()
            {
                Id = Interlocked.Increment(ref lastOrderId),
                Value = paymentValue,
                CustomerId = customerId,
                OrderDate = DateTime.Now,
                Customer = GetCustomer(customerId)

            });
        }
        public async Task<Order> PayOrderPaypal(decimal paymentValue, int customerId)
        {

            //Faz pagamento...

            GetCustomer(customerId);
            return await Task.FromResult(new Order()
            {
                Id = Interlocked.Increment(ref lastOrderId),
                Value = paymentValue,
                CustomerId = customerId,
                OrderDate = DateTime.Now,
                Customer = GetCustomer(customerId)
            });
        }

        public Customer? GetCustomer(int customerId)
        {
            var customer = _ctx.Customers.Where(a => a.Id == customerId).FirstOrDefault();

            if (customer != null)
            {
                return customer;
            }

            throw new Exception("CustomerId não existe");

        }
    }
}