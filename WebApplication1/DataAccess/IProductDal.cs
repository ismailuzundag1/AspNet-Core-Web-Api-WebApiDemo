using WebApiDemo.Models;
using WebApplication1.Entities;

namespace WebApplication1.DataAccess
{
    public interface IProductDal : IEntityRepository<Product>
    {
        List<ProductModel> GetProductsWithDetails();
    }
}
