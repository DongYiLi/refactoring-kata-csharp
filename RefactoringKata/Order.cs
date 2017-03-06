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
            return string.Format("{{\"id\": {0}, \"products\": [{1}]}}",
                id,
                string.Join(", ", _products.Select(p => p.ToJson()))
                );
        }
    }
}