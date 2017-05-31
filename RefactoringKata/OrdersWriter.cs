using System.Collections.Generic;
using System.Text;

namespace RefactoringKata
{
    public class OrdersWriter
    {
        private Orders _orders;

        public OrdersWriter(Orders orders)
        {
            _orders = orders;
        }

        public string GetContents()
        {
            var ordersBuilder = new JsonBuilder(GetOrdersProperties());
            return ordersBuilder.ToJson();
        }

        private Dictionary<string, object> GetOrdersProperties()
        {
            var orders = new List<JsonBuilder>();
            for (var i = 0; i < _orders.GetOrdersCount(); i++)
            {
                var order = _orders.GetOrder(i);
                orders.Add(new JsonBuilder(GetOrderProperties(order)));
            }

            var ordersProperties = new Dictionary<string, object>
            {
                {"orders", orders}
            };
            return ordersProperties;
        }

        private Dictionary<string, object> GetOrderProperties(Order order)
        {
            var products = new List<JsonBuilder>();
            for (var j = 0; j < order.GetProductsCount(); j++)
            {
                var product = order.GetProduct(j);
                products.Add(new JsonBuilder(GetProductProperties(product)));
            }

            var orderProperties = new Dictionary<string, object>
            {
                {"id", order.GetOrderId()},
                {"products", products}
            };
            return orderProperties;
        }

        private Dictionary<string, object> GetProductProperties(Product product)
        {
            var productProperties = new Dictionary<string, object>
            {
                {"code", product.Code},
                {"color", product.GetColorText()}
            };
            if (product.IsSizeApplicable())
            {
                productProperties.Add("size", product.GetSizeText());
            }
            productProperties.Add("price", product.Price);
            productProperties.Add("currency", product.Currency);
            return productProperties;
        }
    }
}