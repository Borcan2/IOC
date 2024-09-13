namespace OnlineStoreAPI.Services
{

    public interface IProductService
    {
        List<string> GetProducts();
    }

    public class ProductService : IProductService
    {

       public List<string> GetProducts()
        {
            return new List<string> { "Laptop", "IPhone", "Airpods" };
        }
    }

}