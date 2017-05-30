using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RefactoringKata
{
    public class Order
    {
        private readonly int id;
        private readonly List<Product> _products = new List<Product>();

        public Order(int id)
        {
            this.id = id;
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public string ToJson()
        {
            var properties = new Dictionary<string, object>
            {
                {"id", id},
                {"products", _products.Select(o => o.ToJson())}
            };

            return JsonHelper.ToJson(properties);
        }
    }
}