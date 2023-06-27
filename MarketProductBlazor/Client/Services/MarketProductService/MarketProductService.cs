using MarketProductBlazor.Client.Pages;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace MarketProductBlazor.Client.Services.MarketProductService
{
    public class MarketProductService : IMarketProductService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public MarketProductService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }
        public List<MarketProduct> Products { get ; set ; } = new List<MarketProduct>();
        public List<Offer> Offers { get ; set ; } = new List<Offer>();

        public async Task CreateProduct(MarketProduct product)
        {
            var result = await _http.PostAsJsonAsync("api/marketproduct", product);
            await SetProducts(result);
        }

        private async Task SetProducts(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<MarketProduct>>();
            Products = response;
            _navigationManager.NavigateTo("marketproducts");
        }

        public async Task DeleteProduct(int id)
        {
            var result = await _http.DeleteAsync($"api/marketproduct/{id}");
            
            await SetProducts(result);
        }

        public async Task GetMarketProducts()
        {
            var result = await _http.GetFromJsonAsync<List<MarketProduct>>("api/marketproduct");
            if (result != null)
            {
                Products = result;
            }
        }

        public async Task GetOffers()
        {
            var result = await _http.GetFromJsonAsync<List<Offer>>("api/marketproduct/offers");
            if (result != null)
                Offers = result;
        }

        public async Task<MarketProduct> GetSingleProduct(int id)
        {
            var result = await _http.GetFromJsonAsync<MarketProduct>($"api/marketproduct/{id}");
            if (result != null)
                return result;
            throw new Exception("Produto não encontrado!");
        }

        public async Task UpdateProduct(MarketProduct product)
        {
            var result = await _http.PutAsJsonAsync($"api/marketproduct/ {product.Id}", product);
            
            await SetProducts(result);
        }
    }
}
