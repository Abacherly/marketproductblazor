using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketProductBlazor.Shared
{
    public class MarketProduct
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Offer? Offer { get; set; }
        public int OfferId { get; set; }

    }
}
