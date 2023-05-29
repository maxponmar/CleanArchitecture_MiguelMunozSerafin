
namespace NorthWind.Sales.BusinessObjects.Aggregates
{
    public class OrderAggregate : Order
    {
        readonly List<OrderDetail> OrderDetailsField = new();
        public IReadOnlyCollection<OrderDetail> OrderDetails => OrderDetailsField.AsReadOnly();

        public void AddDetail(OrderDetail newOrderDetail)
        {
            var ExistingOrderDatail = OrderDetailsField.FirstOrDefault(d => d.ProductId == newOrderDetail.ProductId);

            if (ExistingOrderDatail != default)
            {
                OrderDetailsField.Add(ExistingOrderDatail with
                {
                    Quantity = (short)(newOrderDetail.Quantity + ExistingOrderDatail.Quantity),
                });
                OrderDetailsField.Remove(newOrderDetail);
            }
            else
            {
                OrderDetailsField.Add(newOrderDetail);
            }
        }

        public void AddDetail(int productId, decimal unitPrice, short quantity) => AddDetail(new OrderDetail(productId, unitPrice, quantity));

        public static OrderAggregate From(CreateOrderDTO orderDTO)
        {
            OrderAggregate Order = new OrderAggregate()
            {
                CustomerId = orderDTO.CustomerId,
                ShipAddress = orderDTO.ShipAddress,
                ShipCity = orderDTO.ShipCity,
                ShipCountry = orderDTO.ShipCountry,
                ShipPostalCode = orderDTO.ShipPostalCode,
            };

            foreach (var Item in orderDTO.OrderDetails)
            {
                Order.AddDetail(Item.ProductId, Item.UnitPrice, Item.Quantity);
            }

            return Order;
        }
    }
}
