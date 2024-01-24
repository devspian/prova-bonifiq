using ProvaPub.Models;

namespace ProvaPub.Repository
{
    public class ProductRepository
    {
        TestDbContext _ctx;
        public ProductRepository(TestDbContext ctx)
        {
            _ctx = ctx;
        }

        public ProductList List(int page)
        {
            int itensPorPag = 10;

            var listaOrdenada = _ctx.Products.OrderBy(a => a.Id);
            var totalCount = listaOrdenada.Count();

            var paginatedList = listaOrdenada.Skip((page - 1) * itensPorPag).Take(itensPorPag).ToList();

            bool hasNextPage = (page * itensPorPag) < totalCount;

            return new ProductList()
            {
                HasNext = hasNextPage,
                TotalCount = totalCount,
                Products = paginatedList
            };
        }
    }

}
