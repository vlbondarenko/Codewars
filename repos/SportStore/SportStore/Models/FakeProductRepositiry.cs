using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportStore.Models
{
    public class FakeProductRepositiry:IProductRepository
    {
        public IEnumerable<Product> Products => new List<Product>
        {
            new Product{ Name="Football",Price=25M},
            new Product{ Name="Surf Boadr",Price=179M },
            new Product{ Name="Running shoes",Price=95M}
        };
    }
}
