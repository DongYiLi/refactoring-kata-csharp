using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RefactoringKata
{
    public class Orders
    {
        private List<Order> _orders = new List<Order>();

        public void AddOrder(Order order)
        {
            _orders.Add(order);
        }

        public string ToJson()
        {
            return string.Format("{{\"orders\": [{0}]}}",
                string.Join(", ", _orders.Select(o => o.ToJson())));
        }
    }
}
