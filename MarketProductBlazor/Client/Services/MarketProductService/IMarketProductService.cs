
namespace MarketProductBlazor.Client.Services.MarketProductService
{
    public interface IMarketProductService
    {
        List<MarketProduct> Products { get; set; }
        List<Offer> Offers { get; set; }
        Task GetOffers();
        Task GetMarketProducts();
        Task<MarketProduct> GetSingleProduct(int id);
        Task CreateProduct(MarketProduct product);
        Task UpdateProduct(MarketProduct product);
        Task DeleteProduct(int id);
    }
}
