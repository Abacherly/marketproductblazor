using MarketProductBlazor.Server.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace MarketProductBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketProductController : ControllerBase
    {
        private readonly DataContext _context;

        public MarketProductController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<MarketProduct>>> GetMarketProducts()
        {
        var products = await _context.MarketProducts.Include(sh => sh.Offer).ToListAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MarketProduct>> GetSingleProduct(int id)
        {
            var product = await _context.MarketProducts
                .Include(h => h.Offer)
                .FirstOrDefaultAsync(h => h. Id == id);
            if (product == null)
            {
                return NotFound("Produto não encontrado!");
            }
            return Ok(product);
        }

        [HttpGet("offers")]
        public async Task<ActionResult<Offer>> GetOffers()
        {
            var offers = await _context.Offers.ToListAsync();
            return Ok(offers);
        }

        [HttpPost]
        public async Task<ActionResult<List<MarketProduct>>>  CreateMarketProduct(MarketProduct product)
        {
            product.Offer = null;
            _context.MarketProducts.Add(product);
            await _context.SaveChangesAsync();
            return Ok(await GetDbProducts());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<MarketProduct>>> UpdateMarketProduct(MarketProduct product, int id)
        {
            var dbProduct = await _context.MarketProducts
                .Include (sh => sh.Offer)
                .FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbProduct == null)
                return NotFound("Desculpe, produto não encontrado");
            dbProduct.Name = product.Name;
            dbProduct.Description = product.Description;
            dbProduct.OfferId = product.OfferId;

            await _context.SaveChangesAsync();
            return Ok(await GetDbProducts());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<MarketProduct>>> DeleteMarketProduct(int id)
        {
            var dbProduct = await _context.MarketProducts
                .Include(sh => sh.Offer)
                .FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbProduct == null)
                return NotFound("Desculpe, produto não encontrado");

            _context.MarketProducts.Remove(dbProduct);

            await _context.SaveChangesAsync();
            return Ok(await GetDbProducts());
        }

        private async Task<List<MarketProduct>> GetDbProducts()
        {
            return await _context.MarketProducts.Include(sh => sh.Offer).ToListAsync();
        }
    }
    

}

    

